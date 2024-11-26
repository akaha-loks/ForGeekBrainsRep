using Unity.Entities;
using UnityEngine;

public class BulletMoveSystem : ComponentSystem
{
    private EntityQuery _query;

    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<BulletMoveData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, BulletMoveData bulletMove) =>
        {
            var t = transform.position;

            t += transform.forward * (bulletMove.moveSpeed / 1000);

            transform.position = t;
        });
    }
}
