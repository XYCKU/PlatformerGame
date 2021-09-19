using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
	public delegate void EnemyCollision();
	public static event EnemyCollision OnPlayerEnemyCollision;
	private IMoveHandler<float> _mover;

	private void Awake()
	{
		_mover = GetComponent<IMoveHandler<float>>();
	}
	private void FixedUpdate()
	{
		_mover.Move(1);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<IPlayer>() != null) {
			OnPlayerEnemyCollision?.Invoke();
		}
	}
}
