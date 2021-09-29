using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private InputController _inputController;
	
	private bool _facingLeft;

	[SerializeField] private IJumpable _playerJump;
	[SerializeField] private IJumpable _playerHoldJump;
	private IMovable<float> _playerMovement;
	private IDamageable _healthSystem;

	private void Awake()
	{
		_playerMovement = GetComponent<IMovable<float>>();
		_playerJump = GetComponent<IJumpable>();
		_playerHoldJump = GetComponent<PlayerHoldJump>();
		_healthSystem = GetComponent<HealthSystem>();
	}
	private void OnEnable()
	{
		_inputController.OnPlayerJump += _playerJump.Jump;
		_inputController.OnPlayerHoldJump += _playerHoldJump.Jump;
		
		EnemyHandler.OnPlayerEnemyCollision += _healthSystem.TakeDamage;
	}
	private void OnDisable()
	{
		_inputController.OnPlayerJump -= _playerJump.Jump;
		_inputController.OnPlayerHoldJump -= _playerHoldJump.Jump;

		EnemyHandler.OnPlayerEnemyCollision -= _healthSystem.TakeDamage;
	}
	private void FixedUpdate()
	{
		float inputVelocity = _inputController.GetHorizontalInput();
		Flip(inputVelocity);
		_playerMovement.Move(inputVelocity);
	}
	private void Flip(float input)
	{
		bool old = _facingLeft;
		if (input < 0) {
			_facingLeft = true;
		} else {
			if (input > 0) {
				_facingLeft = false;
			}
		}

		if (old != _facingLeft)
			transform.Rotate(0.0f, 180.0f, 0.0f);
	}
}
