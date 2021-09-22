using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	[SerializeField] private PlayerController _player;
	private void OnEnable()
	{
		_player.OnPlayerDeath += LoseGame;
	}
	private void OnDisable()
	{
		
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
