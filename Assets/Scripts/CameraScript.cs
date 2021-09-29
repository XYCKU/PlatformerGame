using UnityEngine;

public class CameraScript : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _followTarget;
	[SerializeField] private Vector3 _offset;
	[SerializeField] private float _smoothSpeed;
	[SerializeField] private float _smoothSizeSpeed;

	private float _defaultSize;
	private Camera _camera;
	private void Awake()
	{
		_camera = GetComponent<Camera>();
		_defaultSize = _camera.orthographicSize;
	}

	private void LateUpdate()
    {
		transform.position = (Vector3)_followTarget.position + _offset;
    }
	private void Process()
	{
		Vector3 endPosition = new Vector3(_followTarget.position.x, _followTarget.position.y, 0f) + _offset;
		Vector3 currentPosition = Vector3.Lerp(transform.position, endPosition, _smoothSpeed);
		transform.position = currentPosition;

		float newSize = _defaultSize + _followTarget.velocity.magnitude / 7.5f;
		float currentSize = Mathf.Lerp(_camera.orthographicSize, newSize, _smoothSizeSpeed);
		_camera.orthographicSize = currentSize;

	}
}
