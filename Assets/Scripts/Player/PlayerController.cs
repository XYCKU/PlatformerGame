using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private LayerMask _groundLayerMask;
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _groundCheckRadius;
	private Rigidbody2D _rigidbody2D;
	private CircleCollider2D _collider;

	private void Start()
	{
		_groundCheckRadius = 0.1f;
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_collider = GetComponent<CircleCollider2D>();
	}
	private void OnEnable()
	{
		InputController.OnPlayerJump += Jump;
	}
	private void OnDisable()
	{
		InputController.OnPlayerJump -= Jump;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		float velocity = InputController.Instance.GetHorizontalInput() * _moveSpeed * Time.fixedDeltaTime;
		_rigidbody2D.velocity = new Vector2(velocity, _rigidbody2D.velocity.y);
	}
	public void Jump()
	{
		if (IsGrounded()) {
			_rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		}
	}
	private bool IsGrounded()
	{
		RaycastHit2D raycastHit2D = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 
														0f, Vector2.down, _groundCheckRadius, _groundLayerMask);
		return raycastHit2D.collider != null;
	}
	
}
