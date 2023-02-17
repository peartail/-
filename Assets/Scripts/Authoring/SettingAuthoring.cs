using Unity.Entities;

public class SettingAuthoring : UnityEngine.MonoBehaviour
{
    int unitCount;
    UnityEngine.GameObject unitPrefab;

    int targetCount;
    UnityEngine.GameObject targetPrefab;

    public class SettingBaker : Baker<SettingAuthoring>
    {
        public override void Bake(SettingAuthoring authoring)
        {
            //AddComponent(new SettingComponentData { });
        }
    }
}


struct SettingComponentData : IComponentData
{
    //public float3 Position
}