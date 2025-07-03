using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }

	private Controls _playerInputActions;

	public static Vector2 Movement { get; private set; }
	public static bool JumpWasPressed { get; private set; }
	public static bool JumpIsHeld { get; private set; }
	public static bool JumpWasReleased { get; private set; }
	public static bool AttackWasPressed { get; private set; }
	public static bool AttackIsHeld { get; private set; }
	public static bool AttackWasReleased { get; private set; }
	public static bool PauseWasPressed { get; private set; }
	//public static bool UnPauseWasPressed { get; private set; }

    private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		_playerInputActions = new Controls();

		//Подписываемся на события
		//_playerInputActions.Player.Move.performed += context => Movement = context.ReadValue<Vector2>();

		//Подписываемся на события, и выключаем лишние action, которые могут мешаться
		//_playerInputActions.Player.Jump.started += JumpStarted;
		//_playerInputActions.Player.Jump.canceled += JumpCancelled;
		//_playerInputActions.Player.Attack.started += AttackStarted;
		//_playerInputActions.Player.Attack.canceled += AttackCancelled;
	}

	private void OnEnable()
	{
		_playerInputActions.Player.Enable();
	}

	private void OnDisable()
	{
		_playerInputActions.Player.Disable();
	}

	private void Update()
	{
		//Не нужно читать ввод каждый кадр, события уже обновляют переменные
		Movement = _playerInputActions.Player.Move.ReadValue<Vector2>();

		JumpWasPressed = _playerInputActions.Player.Jump.WasPressedThisFrame();
		JumpIsHeld = _playerInputActions.Player.Jump.IsPressed();
		JumpWasReleased = _playerInputActions.Player.Jump.WasReleasedThisFrame();

		AttackWasPressed = _playerInputActions.Player.Attack.WasPressedThisFrame();
		AttackIsHeld = _playerInputActions.Player.Attack.IsPressed();
		AttackWasReleased = _playerInputActions.Player.Attack.WasReleasedThisFrame();

        PauseWasPressed = _playerInputActions.Player.Pause.WasPressedThisFrame();
        //UnPauseWasPressed = _playerInputActions.Unpause.WasPressedThisFrame();



    }

 //   public void SwitchToActionMap(string actionMapName)
	//{
	//	// Find Action Map and disable them (no global anymore)

	//	_playerInputActions.Player.Disable();
	//	_playerInputActions.UI.Disable();
	//	//_playerInputActions.Menu.Disable();

	//	switch (actionMapName)
	//	{
	//		case "Player":
	//			_playerInputActions.Player.Enable();
	//			_playerInputActions.UI.Disable();
	//			//_playerInputActions.Menu.Disable();
	//			Debug.Log("Load Player action maps");
	//			_actionMapName = "Player";
	//			break;
	//		case "UI":
	//			_playerInputActions.UI.Enable();
	//			_playerInputActions.Player.Disable();
	//			//_playerInputActions.Menu.Disable();
	//			Debug.Log("Load UI action maps");
	//			_actionMapName = "UI";
	//			break;
	//		//case "Menu":
	//		//    _playerInputActions.Menu.Enable();
	//		//    _playerInputActions.Player.Disable();
	//		//    _playerInputActions.UI.Disable();
	//		//    Debug.Log("Load Menu action maps");
	//		//    _actionMapName = "Menu";
	//		//    break;
	//		default:
	//			Debug.LogError("Invalid action map name: " + actionMapName);
	//			break;
	//	}
	//}

	//private void JumpStarted(InputAction.CallbackContext context)
	//{
	//	//Check to make sure the UI is not enable;
	//	if (_actionMapName == "Player")
	//		JumpWasPressed = true;
	//}
	//private void JumpCancelled(InputAction.CallbackContext context)
	//{
	//	//Check to make sure the UI is not enable;
	//	if (_actionMapName == "Player")
	//		JumpWasReleased = true;
	//}

	//private void AttackStarted(InputAction.CallbackContext context)
	//{
	//	//Check to make sure the UI is not enable;
	//	if (_actionMapName == "Player")
	//		AttackWasPressed = true;
	//}
	//private void AttackCancelled(InputAction.CallbackContext context)
	//{
	//	//Check to make sure the UI is not enable;
	//	if (_actionMapName == "Player")
	//		AttackWasReleased = true;
	//}
}