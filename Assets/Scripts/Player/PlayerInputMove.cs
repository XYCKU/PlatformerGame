using UnityEngine;

public class PlayerInputMove : MonoBehaviour, IMoveHandler<float>
{
	[SerializeField] private float _moveSpeed;
	private Rigidbody2D _rigidbody2D;
	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void Move(float inputVelocity)
	{
		_rigidbody2D.velocity = new Vector2(inputVelocity * _moveSpeed * Time.fixedDeltaTime, 
											_rigidbody2D.velocity.y);
	}
}
