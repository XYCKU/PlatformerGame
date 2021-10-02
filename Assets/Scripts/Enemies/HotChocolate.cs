using UnityEngine;

public class HotChocolate : MonoBehaviour
{
	private IMovable<float> _enemyMovement;
	private IShooter<Player> _enemyShooter;
	private Rigidbody2D _rigidbody2D;
	private bool _facingLeft;

	private void Awake()
	{
		_enemyMovement = GetComponent<IMovable<float>>();
		_enemyShooter = GetComponent<IShooter<Player>>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	private void FixedUpdate()
	{
		_enemyMovement.Move(1);
		Flip(_rigidbody2D.velocity.normalized.x);
	}
	private void Flip(float input)
	{
		bool old = _facingLeft;
		if (input < 0) {
			_facingLeft = true;
		} else {
			if (input > 0) {
				_facingLeft = false;
			}
		}

		if (old != _facingLeft)
			transform.Rotate(0.0f, 180.0f, 0.0f);
	}
}
