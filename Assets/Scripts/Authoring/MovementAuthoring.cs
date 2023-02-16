using Unity.Entities;
using Unity.Mathematics;

public class MovementAuthoring : UnityEngine.MonoBehaviour
{
    public class MovementBaker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {
            //AddComponent<Movment>();
        }
    }
}


struct Movement : IComponentData
{
    //public float3 Position;
}