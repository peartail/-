using System.Numerics;
using Unity.Entities;
using UnityEngine.InputSystem;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Jobs;
using Unity.Collections;

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



public partial class MouseClickSystem : SystemBase
{

    struct Pick : IJob
    {
        [ReadOnly] public CollisionWorld collisionWorld;
        public RaycastInput rayInput;


        public void Execute()
        {
        }
    }


    protected override void OnCreate()
    {
        RequireForUpdate<MouseClickComponentData>();
    }

    protected override void OnDestroy()
    {
        
    }
    protected override void OnUpdate()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && CameraSingleton.Instance is var cam && cam)
        {

            var pos = Mouse.current.position.ReadValue();
            var ray = cam.ScreenPointToRay(pos);


            var world = SystemAPI.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;

            //Dependency = new 

        }
    }
}

