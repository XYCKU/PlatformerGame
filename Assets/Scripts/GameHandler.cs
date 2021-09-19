using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	private void OnEnable()
	{
		EnemyHandler.OnPlayerEnemyCollision += LoseGame;
	}
	private void OnDisable()
	{
		EnemyHandler.OnPlayerEnemyCollision -= LoseGame;
	}
	private void LoseGame()
	{
		Debug.Log("Game lost!");
		RestartGame();
	}
	private void RestartGame()
	{
		Debug.Log("Restarting Level");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
