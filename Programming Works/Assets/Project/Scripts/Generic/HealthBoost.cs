using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : PowerUp
{
	public int healthIncrease;

	public override void Activate(GameObject player)
	{
		Debug.Log($"{powerUpName} activated! Health increased by {healthIncrease}.");

	}

	public override void Deactivate(GameObject player)
	{
		Debug.Log($"{powerUpName} deactivated!");
	}
}
