using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private InputController _inputController;
	private IMoveHandler<float> _mover;
	private IJumpHandler _jumper;
	private IHoldJumpHandler _holdJumper;

	private void Awake()
	{
		_mover = GetComponent<IMoveHandler<float>>();
		_jumper = GetComponent<IJumpHandler>();
		_holdJumper = GetComponent<IHoldJumpHandler>();
	}
	private void OnEnable()
	{
		InputController.OnPlayerJump += _jumper.Jump;
		InputController.OnPlayerHoldJump += _holdJumper.HoldJump;
	}
	private void OnDisable()
	{
		InputController.OnPlayerJump -= _jumper.Jump;
		InputController.OnPlayerHoldJump -= _holdJumper.HoldJump;
	}
	private void FixedUpdate()
	{
		_mover.Move(_inputController.GetHorizontalInput());
	}
}
