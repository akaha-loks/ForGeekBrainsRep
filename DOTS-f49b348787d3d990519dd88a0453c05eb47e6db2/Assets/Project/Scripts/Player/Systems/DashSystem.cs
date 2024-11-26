﻿using Unity.Entities;
using UnityEngine;

public class DashSystem : ComponentSystem
{
    private EntityQuery _dashQuary;

    protected override void OnCreate()
    {
        _dashQuary = GetEntityQuery(ComponentType.ReadOnly<DashComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_dashQuary).ForEach(
            (Entity entity, ref InputData input, UserInputData inputData, Transform transform, DashComponent dash) =>
            {
                var t = transform.position;

                if (dash.canDash == true && input.Dash > 0 && inputData != null && inputData.DashAction is IAbility ability)
                {
                    dash.Execute();
                    transform.position += transform.forward * (dash.dashPower / 100);
                }

                transform.position = t;
            });
    }
}