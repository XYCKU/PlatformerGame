using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
	[SerializeField] private Camera _camera;
	[SerializeField] private float _parallaxMultiplier;

	private float _length;
	private float _startPosition;

	private void Start()
	{
		_startPosition = transform.position.x;
		_length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	private void FixedUpdate()
	{
		float distance = (_camera.transform.position.x * _parallaxMultiplier);
		float temp = (_camera.transform.position.x * (1 - _parallaxMultiplier));

		transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

		if (temp > _startPosition + _length) {
			_startPosition += _length;
		} else {
			if (temp < _startPosition - _length) {
				_startPosition -= _length;
			}
		}
	}
}
