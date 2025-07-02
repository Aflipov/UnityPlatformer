using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

	private InputAction moveAction;
    private InputAction jumpAction;

	private Vector2 movementInput;

	public float xInput;
	public float yInput;

	public bool jumpInput;

	private void Start()
	{		
		moveAction = InputSystem.actions.FindAction("Move");
		jumpAction = InputSystem.actions.FindAction("Jump");
	}

	private void Update()
	{
		movementInput = moveAction.ReadValue<Vector2>();
		xInput = Mathf.RoundToInt(movementInput.x);
		yInput = Mathf.RoundToInt(movementInput.y);

		jumpInput = jumpAction.IsPressed();
	}
}
