using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour, IMovable<float>
{
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _minDistance;
	[SerializeField] private IPatrolPath _patrolPath;
	private Transform[] _pathPoints;
	private int _pointIndex;
	private Rigidbody2D _rigidbody2D;
	
	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_pathPoints = _patrolPath.GetComponentsInChildren<Transform>();
		MoveToNext();
	}
	private void MoveToNext()
	{
		_pointIndex = (_pointIndex + 1) % _pathPoints.Length;
	}
	public void Move(float inputVelocity)
	{
		Vector2 difference = (Vector2) transform.position - (Vector2) _pathPoints[_pointIndex].position; 
		float distance = difference.sqrMagnitude;
		
		if (difference.x > 0) {
			inputVelocity *= -1;
		}
		
		if (distance <= _minDistance) {
			MoveToNext();
			return;
		}
		
		_rigidbody2D.velocity = new Vector2(inputVelocity * _moveSpeed, _rigidbody2D.velocity.y);
	}
}
