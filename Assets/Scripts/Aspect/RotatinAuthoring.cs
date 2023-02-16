using Unity.Entities;

public class RotatinAuthoring : UnityEngine.MonoBehaviour
{
    public class RotatinBaker : Baker<RotatinAuthoring>
    {
        public override void Bake(RotatinAuthoring authoring)
        {
            //AddComponent<Rotatin>();
        }
    }
}


struct RotatinComponentData : IComponentData
{
    //public float3 Position
}