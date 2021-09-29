using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	[SerializeField] private Player _player;
	private HealthSystem _playerHealthSystem;
	private void Awake()
	{
		_playerHealthSystem = _player.GetComponent<HealthSystem>();
	}
	private void OnEnable()
	{
		_playerHealthSystem.OnDeath += LoseGame;
	}
	private void OnDisable()
	{
		_playerHealthSystem.OnDeath -= LoseGame;
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
