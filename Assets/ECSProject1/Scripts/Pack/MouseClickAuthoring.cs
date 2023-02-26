using Unity.Entities;
using UnityEngine.InputSystem;
using Unity.Physics;
using Unity.Jobs;
using Unity.Collections;
using Unity.Assertions;
using Unity.Mathematics;
using System.Diagnostics;
using Unity.Transforms;
using Unity.Entities.UniversalDelegates;

namespace InputUtil
{

    public struct MouseClickController : ICollector<RaycastHit>
    {

        public bool EarlyOutOnFirstHit => false;

        public float MaxFraction { get; private set; }

        public int NumHits { get; private set; }
        private RaycastHit _ClosestHit;
        public RaycastHit Hit => _ClosestHit;

        public bool IgnoreTriggers;
        public bool IgnoreStatic;
        public NativeArray<RigidBody> Bodies;
        public int NumDynamicBodies;

        public MouseClickController(float maxFraction, NativeArray<RigidBody> bodies, int numDynamicBodies)
        {
            MaxFraction = maxFraction;
            Bodies = bodies;
            NumDynamicBodies = numDynamicBodies;
            _ClosestHit = default;
            NumHits = 0;
            IgnoreStatic = true;
            IgnoreTriggers = true;
        }

        public bool AddHit(RaycastHit hit)
        {
            Assert.IsTrue(hit.Fraction <= MaxFraction);
            var isAcceptable = true;

            if (IgnoreStatic)
            {
                isAcceptable = isAcceptable && (hit.RigidBodyIndex >= 0) && (hit.RigidBodyIndex < NumDynamicBodies);
            }

            if (IgnoreTriggers)
            {
                isAcceptable = isAcceptable && hit.Material.CollisionResponse != CollisionResponsePolicy.RaiseTriggerEvents;
            }

            if (!isAcceptable)
            {
                return false;
            }

            MaxFraction = hit.Fraction;
            _ClosestHit = hit;
            NumHits = 1;
            return true;
        }
    }


    public class MouseClickAuthoring : UnityEngine.MonoBehaviour
    {
        public bool IgnoreTriggers = true;
        public bool IgnoreStatic = true;
        public class MouseClickBaker : Baker<MouseClickAuthoring>
        {
            public override void Bake(MouseClickAuthoring authoring)
            {
                AddComponent(new MouseClickComponentData
                {
                    IgnoreStatic = authoring.IgnoreStatic,
                    IgnoreTriggers = authoring.IgnoreTriggers,
                });
            }
        }
    }


    struct MouseClickComponentData : IComponentData
    {
        public bool IgnoreTriggers;
        public bool IgnoreStatic;
    }



    public partial struct MouseClickSystem : ISystem
    {
        public static readonly float _MaxDistance = 100f;
        struct Pick : IJob
        {
            //[ReadOnly] public CollisionWorld collisionWorld;
            //public RaycastInput rayInput;
            //[ReadOnly] public bool IgnoreTriggers;
            //public float Near;
            //public float3 Forward;
            [ReadOnly] public UnityEngine.Plane plane;
            [ReadOnly] public UnityEngine.Ray ray;
            public float3 hitPosition;

            public void Execute()
            {
               
                //var mousePickController = new MouseClickController(1f, collisionWorld.Bodies, collisionWorld.NumDynamicBodies);
                //if (collisionWorld.CastRay(rayInput, ref mousePickController))
                //{
                //    var fraction = mousePickController.Hit.Fraction;
                //    UnityEngine.Debug.Log(mousePickController.Hit.Position);

                //}
            }
        }


        public void OnCreate(ref SystemState state)
        {
            state.Enabled = false;
            state.RequireForUpdate<MouseClickComponentData>();
        }

        public void OnDestroy(ref SystemState state)
        {
          
        }

        void Spawn(ref SystemState state, Entity prefab, float3 position)
        {

            var unit = state.EntityManager.Instantiate(prefab);
            state.EntityManager.SetComponentData(unit,
                    new LocalTransform { Position = position, Scale = 1 });
        }

        public void OnUpdate(ref SystemState state)
        {
            UnityEngine.Plane p = new UnityEngine.Plane(UnityEngine.Vector3.up, 0);
            //Plane p2 = new Plane(new float3(0, 1, 0), 0);
            
            if (Mouse.current.leftButton.wasPressedThisFrame && CameraSingleton.Instance is var cam && cam)
            {
                var setting = SystemAPI.GetSingleton<SettingComponentData>();
                var pos = Mouse.current.position.ReadValue();
                var ray = cam.ScreenPointToRay(pos);


                //var world = SystemAPI.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;

                //var job = new Pick
                //{
                //    ray = ray,
                //    plane = p,
                //    //collisionWorld = world.CollisionWorld,
                //    //rayInput = new RaycastInput
                //    //{
                //    //    Start = ray.origin,
                //    //    End = ray.origin + ray.direction * _MaxDistance,
                //    //    Filter = CollisionFilter.Default,
                //    //},

                //};
                //var handle = job.Schedule();
                //handle.Complete();

                if (p.Raycast(ray, out var enter))
                {
                    var hitPosition = ray.GetPoint(enter);

                    UnityEngine.Debug.Log($"Pos : {pos} , Hit : {hitPosition}");
                    Spawn(ref state, setting.unitEntity , hitPosition);
                   
                }

            }

        }


        //void Spawn(ref SystemState state, float3 pos)
        //{
        //    var setting = SystemAPI.GetSingleton<SettingComponentData>();
        //    var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        //    var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        //    var vehicles = CollectionHelper.CreateNativeArray<Entity>(setting.unitCount, Allocator.Temp);
        //    ecb.Instantiate(setting.unitEntity, vehicles);


        //}
    }


}