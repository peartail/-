using Unity.Entities;

public class RotationAuthoring : UnityEngine.MonoBehaviour
{
    public class RotationBaker : Baker<RotationAuthoring>
    {
        public override void Bake(RotationAuthoring authoring)
        {
            //AddComponent<Rotation>();
        }
    }
}


struct Rotation : IComponentData
{
    //public float3 Position
}