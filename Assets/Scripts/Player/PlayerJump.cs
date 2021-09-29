using UnityEngine;

public class PlayerJump : MonoBehaviour, IJumpable
{
	[SerializeField] protected Rigidbody2D _rigidbody2D;
	[SerializeField] protected Collider2D _collider;
	[SerializeField] protected LayerMask _groundLayer;
	[SerializeField] protected float _groundCheckRadius;
	[SerializeField] protected float _jumpForce;
	public virtual void Jump()
	{
		if (!CheckGround()) return;
		
		Vector2 newVelocity = new Vector2(0f, _jumpForce);
		_rigidbody2D.velocity = newVelocity;
	}
	protected bool CheckGround()
	{
		RaycastHit2D raycastHit2D = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, 
													Vector2.down, _groundCheckRadius, _groundLayer);
		return raycastHit2D.collider != null;

		//Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheckPosition.position, _groundCheckRadius, _layerMask);*/

		//_isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _layerMask);
	}
}
