using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool JumpWasPressed;
    public static bool JumpIsHeld;
    public static bool JumpWasReleased;
    public static bool AttackWasPressed;
    public static bool AttackIsHeld;
    public static bool AttackWasReleased;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _attackAction;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _attackAction = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        JumpWasPressed = _jumpAction.WasPressedThisFrame();
        JumpIsHeld = _jumpAction.IsPressed();
        JumpWasReleased = _jumpAction.WasReleasedThisFrame();

        AttackWasPressed = _attackAction.WasPressedThisFrame();
        AttackIsHeld = _attackAction.IsPressed();
        AttackWasReleased = _attackAction.WasReleasedThisFrame();
    }
}