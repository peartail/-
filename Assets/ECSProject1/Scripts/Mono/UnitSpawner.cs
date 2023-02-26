using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSpawner : MonoBehaviour, Action.IMainActions
{
    Action action;
    bool isClicked = false;
    Vector2 position= Vector2.zero;

    public void OnClick_1(InputAction.CallbackContext context)
    {
        isClicked = true;

        var setting = SystemAPI.GetSingleton<SettingComponentData>();

        var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        
        //var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        //var vehicles = CollectionHelper.CreateNativeArray<Entity>(setting.unitCount, Allocator.Temp);
        //ecb.Instantiate(setting.unitEntity, vehicles);

        //setting.unitEntity
    }

    public void OnTouchPosition(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }

    void Start()
    {
        action = new Action();
        action.main.SetCallbacks(this);
    }

    private void OnEnable()
    {
        action.main.Enable();
    }

    private void OnDisable()
    {
        action.main.Disable();
    }

    
    void Update()
    {
        
    }
}
