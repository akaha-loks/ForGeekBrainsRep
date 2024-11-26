using Unity.Entities;
using UnityEngine;

public class PlayerShootSystem : ComponentSystem
{
    private EntityQuery _shootQuary;

    protected override void OnCreate()
    {
        _shootQuary = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<UserInputData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_shootQuary).ForEach(
            (Entity entity, UserInputData inputData, ref InputData input) =>
            {
                if (input.Shoot > 0f && inputData != null && inputData.ShootAction is IAbility ability)
                {
                    ability.Execute();
                }
            });
    }
}