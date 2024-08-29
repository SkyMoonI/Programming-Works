using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
	public float speedMultiplier;

	public override void Activate(GameObject player)
	{
		Debug.Log($"{powerUpName} activated! Speed multiplied by {speedMultiplier}.");
	}

	public override void Deactivate(GameObject player)
	{
		Debug.Log($"{powerUpName} expired.");
	}
}
