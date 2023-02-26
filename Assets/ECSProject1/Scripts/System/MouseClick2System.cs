using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public partial struct MouseClick2System : ISystem, Action.IMainActions
{
    static float2 clickPos;
    static bool clicked;

    public void OnTouchPosition(InputAction.CallbackContext context)
    {
        clickPos = context.ReadValue<Vector2>();
    }
    public void OnClick_1(InputAction.CallbackContext context)
    {
        clicked = true;
    }


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Init()
    {

    }

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        var action = new Action();
        action.main.SetCallbacks(this);
        action.main.Enable();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

   
   
    void Spawn(ref SystemState state, Entity prefab, float3 position)
    {

        var unit = state.EntityManager.Instantiate(prefab);
        state.EntityManager.SetComponentData(unit,
                new LocalTransform { Position = position, Scale = 1 });
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (clicked)
        {
            clicked = false;
            if (CameraSingleton.Instance is var cam && cam)
            {
                var setting = SystemAPI.GetSingleton<SettingComponentData>();
                var pos = Mouse.current.position.ReadValue();
                var ray = cam.ScreenPointToRay(pos);
                Plane p = new Plane(Vector3.up, 0);
                if (p.Raycast(ray, out var enter))
                {
                    var hitPosition = ray.GetPoint(enter);

                    Spawn(ref state, setting.unitEntity, hitPosition);

                }
            }
            
        }
    }
}


//[BurstCompile]
//public partial struct MouseClick2Job : IJobEntity
//{
//	public float Delta;

//	void Execute(ref LocalTransform transform, in MouseClick2ComponentData value)
//	{
//	}
//}