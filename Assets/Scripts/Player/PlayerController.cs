using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	[SerializeField] private InputController _inputController;
	private IMoveHandler<float> _mover;
	private IJumpHandler _jumper;
	private IHoldJumpHandler _holdJumper;
	private IDamageable _damageable;
	private DamageSystem _damageSystem;

	public delegate void PlayerEvent();
	public event PlayerEvent OnPlayerDeath;

	private void Awake()
	{
		_mover = GetComponent<IMoveHandler<float>>();
		_jumper = GetComponent<IJumpHandler>();
		_holdJumper = GetComponent<IHoldJumpHandler>();
		_damageable = GetComponent<IDamageable>();
		_damageSystem = GetComponent<DamageSystem>();
	}
	private void OnEnable()
	{
		_inputController.OnPlayerJump += _jumper.Jump;
		_inputController.OnPlayerHoldJump += _holdJumper.HoldJump;
		
		_damageSystem.OnDeath += OnDeath;

		EnemyHandler.OnPlayerEnemyCollision += _damageable.TakeDamage;
	}
	private void OnDisable()
	{
		_inputController.OnPlayerJump -= _jumper.Jump;
		_inputController.OnPlayerHoldJump -= _holdJumper.HoldJump;

		_damageSystem.OnDeath -= OnDeath;

		EnemyHandler.OnPlayerEnemyCollision -= _damageable.TakeDamage;
	}
	private void FixedUpdate()
	{
		_mover.Move(_inputController.GetHorizontalInput());
	}
	private void OnDeath()
	{
		OnPlayerDeath?.Invoke();
	}

}
