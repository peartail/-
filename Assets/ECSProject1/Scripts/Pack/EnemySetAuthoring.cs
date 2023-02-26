using Unity.Entities;

public class EnemySetAuthoring : UnityEngine.MonoBehaviour
{
    public class EnemySetBaker : Baker<EnemySetAuthoring>
    {
        public override void Bake(EnemySetAuthoring authoring)
        {
            //AddComponent(new EnemySetComponentData { });
        }
    }
}


struct EnemySetComponentData : IComponentData
{
    //public float3 Position
}