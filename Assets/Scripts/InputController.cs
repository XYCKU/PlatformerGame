using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
	private InputAction _movement;
	private InputAction _jump;
	private PlayerInputActions _playerInputActions;

	public delegate void HInputEvent(float inputValue);
	public delegate void InputEvent();
	public static event HInputEvent OnPlayerHInput;
	public static event InputEvent OnPlayerJump;
	public static event InputEvent OnPlayerHoldJump;

	private void Awake()
	{
		_playerInputActions = new PlayerInputActions();
	}
	private void OnEnable()
	{
		_movement = _playerInputActions.Player.Movement;
		_jump = _playerInputActions.Player.Jump;

		_movement.performed += Move;
		_movement.Enable();
		
		_jump.performed += Jump;
		_jump.canceled += HoldJump;
		_jump.Enable();
	}
	private void OnDisable()
	{
		_movement.performed -= Move;
		_movement.Disable();

		_jump.performed -= Jump;
		_jump.canceled -= HoldJump;
		_jump.Disable();
	}
	private void Jump(InputAction.CallbackContext context)
	{
		OnPlayerJump?.Invoke();
	}
	private void HoldJump(InputAction.CallbackContext context)
	{
		OnPlayerHoldJump?.Invoke();
	}
	private void Move(InputAction.CallbackContext context)
	{
		OnPlayerHInput?.Invoke(GetHorizontalInput());
	}
	public float GetHorizontalInput()
	{
		float horizontalInput = _playerInputActions.Player.Movement.ReadValue<float>();
		return horizontalInput;
	}
}
