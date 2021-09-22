using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
	public delegate void CollisionDelegate(IAttacker attacker);
	public static CollisionDelegate OnPlayerEnemyCollision;
	private IMoveHandler<float> _mover;
	private IAttacker _attacker;

	private void Awake()
	{
		_attacker = GetComponent<IAttacker>();
		_mover = GetComponent<IMoveHandler<float>>();
	}
	private void FixedUpdate()
	{
		_mover.Move(1);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<IPlayer>() != null) {
			OnPlayerEnemyCollision?.Invoke(_attacker);
		}
	}
}
