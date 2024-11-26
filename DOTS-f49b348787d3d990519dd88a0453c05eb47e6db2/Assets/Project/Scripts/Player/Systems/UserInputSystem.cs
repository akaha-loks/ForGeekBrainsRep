using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using UnityEngine;

public class UserInputSystem : ComponentSystem
{
    private EntityQuery _inputQuary;
    
    private InputAction _moveAction;
    private float2 _moveInput;

    private InputAction _shootAction;
    private float _shootInput;

    private InputAction _dashAction;
    private float _dashInput;

    protected override void OnCreate()
    {
        _inputQuary = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();

        _shootAction = new InputAction("shoot", binding: "<Keyboard>/Space");
        _shootAction.performed += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.Enable();

        _dashAction = new InputAction("dash", binding: "<Keyboard>/leftShift");
        _dashAction.performed += context => { _dashInput = context.ReadValue<float>(); };
        _dashAction.started += context => { _dashInput = context.ReadValue<float>(); };
        _dashAction.canceled += context => { _dashInput = context.ReadValue<float>(); };
        _dashAction.Enable();
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _dashAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_inputQuary).ForEach(
            (Entity entity, ref InputData inputData) =>
            { 
                inputData.Move = _moveInput;
                inputData.Shoot = _shootInput;
                inputData.Dash = _dashInput;
            });
    }
}