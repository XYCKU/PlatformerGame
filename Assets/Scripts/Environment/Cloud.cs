using System.Collections;
using UnityEngine;

public class Cloud : MonoBehaviour, ICloud
{
	private float _moveSpeed;
	private Vector2 _moveDirection;
	private Vector2 _removePosition;
	private void Start()
	{
		StartCoroutine(Move());
	}
	public void SetValues(Vector2 dir, Vector2 removePos, float speed)
	{
		_moveDirection = dir.normalized;
		_removePosition = removePos;
		_moveSpeed = speed;
	}
	public IEnumerator Move()
	{
		while (true) {
			transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
			if (transform.position.x > _removePosition.x || transform.position.y > _removePosition.y) {
				Destroy(gameObject);
			}
			yield return null;
		}
	}
}
