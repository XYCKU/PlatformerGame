using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRemover : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<ICloud>() != null) {
			Destroy(collision.gameObject);
		}
	}
}
