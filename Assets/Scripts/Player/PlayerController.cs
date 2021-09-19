using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private InputController _inputController;
	private IMoveHandler<float> _mover;
	private IJumpHandler _jumper;

	private void Awake()
	{
		_mover = GetComponent<IMoveHandler<float>>();
		_jumper = GetComponent<IJumpHandler>();
	}
	private void OnEnable()
	{
		InputController.OnPlayerJump += _jumper.Jump;
	}
	private void OnDisable()
	{
		InputController.OnPlayerJump -= _jumper.Jump;
	}
	private void FixedUpdate()
	{
		_mover.Move(_inputController.GetHorizontalInput());
	}
}
