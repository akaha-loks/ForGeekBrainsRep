using Unity.Entities;
using UnityEngine;

public class EnemyMoveSystem : ComponentSystem
{
    private EntityQuery _query;

    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<EnemyMoveComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, EnemyMoveComponent enemyMove) =>
        { 
            var p = transform.position;
            var r = transform.rotation;

            r.y -= (enemyMove.moveSpeed / 1000);
            p.x += (enemyMove.moveSpeed / 1000);

            transform.rotation = r;
            transform.position = p;
        });
    }
}
