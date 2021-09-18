using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	private void OnEnable()
	{
		EnemyController.OnPlayerEnemyCollision += LoseGame;
	}
	private void OnDisable()
	{
		EnemyController.OnPlayerEnemyCollision -= LoseGame;
	}
	private void LoseGame()
	{
		Debug.Log("Game lost!");
		RestartGame();
	}
	private void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
