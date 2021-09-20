using UnityEngine;

public class PlayerInputJump : MonoBehaviour, IJumpHandler, IHoldJumpHandler
{
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _groundCheckRadius;
	[SerializeField] private LayerMask _layerMask;
	private Rigidbody2D _rigidbody2D;
	private Collider2D _collider;
	private void Start()
	{
		_collider = GetComponent<CircleCollider2D>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void Jump()
	{
		if (IsGrounded()) {
			_rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		}
	}
	public void HoldJump()
	{
		if (IsGrounded()) {
			_rigidbody2D.AddForce(Vector2.up * _jumpForce * 2, ForceMode2D.Impulse);
		}
	}
	private bool IsGrounded()
	{
		RaycastHit2D raycastHit2D = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size * 0.9f,
														0f, Vector2.down, _groundCheckRadius, _layerMask);
		return raycastHit2D.collider != null;
	}
}
