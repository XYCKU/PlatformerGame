using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	[SerializeField] LayerMask _layerMask;
	private bool _isGrounded;
	public bool IsGrounded => _isGrounded;

	private void OnTriggerStay2D(Collider2D collision)
	{
		_isGrounded = collision != null && (((1 << collision.gameObject.layer) & _layerMask) != 0);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		_isGrounded = false;
	}
}
