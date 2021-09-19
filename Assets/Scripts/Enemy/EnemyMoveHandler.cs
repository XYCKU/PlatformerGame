using UnityEngine;

public class EnemyMoveHandler : MonoBehaviour, IMoveHandler<float>
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
		float difference = Utility.xDistance(_rigidbody2D.transform.position, 
											_pathPoints[_pointIndex].position);

		if (Mathf.Abs(difference) <= _minDistance) {
			MoveToNext();
			return;
		}

		if (difference > 0) {
			inputVelocity *= -1;
		}

		_rigidbody2D.velocity = new Vector2(inputVelocity * _moveSpeed * Time.fixedDeltaTime,
											_rigidbody2D.velocity.y);
	}
}
