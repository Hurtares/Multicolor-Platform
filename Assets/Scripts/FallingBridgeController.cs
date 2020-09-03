using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridgeController : MonoBehaviour
{
	[SerializeField] Rigidbody2D Rigidbody2D;

	bool IsLowered;

	public void LowerBridge()
	{
		if ( !IsLowered )
		{
			Rigidbody2D.AddForceAtPosition(Vector2.left*150, transform.up);
			IsLowered = true;
		}
	}
}
