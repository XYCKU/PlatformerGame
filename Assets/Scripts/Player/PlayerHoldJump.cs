using UnityEngine;

public class PlayerHoldJump : PlayerJump
{
	[SerializeField] private float _jumpMultiplier;
	public override void Jump()
	{
		if (!base.CheckGround()) return;
		
		Vector2 newVelocity = new Vector2(0f, _jumpForce * _jumpMultiplier);
		_rigidbody2D.velocity = newVelocity;
	}
}
