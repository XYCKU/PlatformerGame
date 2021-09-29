using UnityEngine;

public class HotChocolate : MonoBehaviour
{
	private IMovable<float> _enemyMovement;
	private IShooter _enemyShooter;
	private bool _facingLeft;

	private void Awake()
	{
		_enemyMovement = GetComponent<IMovable<float>>();
		_enemyShooter = GetComponent<IShooter>();
	}
	private void FixedUpdate()
	{
		_enemyMovement.Move(1);
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
