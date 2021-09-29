using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable<float>
{
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private float _moveSpeed;

	public void Move(float inputVelocity)
	{
		float movementSpeed = inputVelocity * _moveSpeed;
		Vector2 newVelocity = new Vector2(movementSpeed, _rigidbody2D.velocity.y);
		_rigidbody2D.velocity = newVelocity;
	}
}
