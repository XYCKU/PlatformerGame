using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public delegate void EnemyCollision();
	public static event EnemyCollision OnPlayerEnemyCollision;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Player>() != null) {
			OnPlayerEnemyCollision?.Invoke();
		}
	}
}
