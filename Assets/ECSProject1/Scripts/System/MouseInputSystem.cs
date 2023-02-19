using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine.InputSystem;
using Unity.Entities.UniversalDelegates;
using UnityEngine.UIElements;

[BurstCompile]
public partial struct MouseInputSystem : ISystem
{
    //SettingComponentData setting;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SettingComponentData>();
        

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var setting = SystemAPI.GetSingleton<SettingComponentData>();
        if (Mouse.current.IsPressed())
        {
            var pos = Mouse.current.position.ReadDefaultValue();

            var entity = state.EntityManager.Instantiate(setting.targetEntity);
            state.EntityManager.SetComponentData(entity,
               new LocalTransform { Position = new Unity.Mathematics.float3(pos.x,0,pos.y), Scale = 1 });
        }


        //var job = new MouseInputJob { };
        //job.ScheduleParallel();
    }
}


//[BurstCompile]
//public partial struct MouseInputJob : IJobEntity
//{
//	public float Delta;

//	void Execute(ref LocalTransform transform, in MouseInputComponentData value)
//	{
//	}
//}