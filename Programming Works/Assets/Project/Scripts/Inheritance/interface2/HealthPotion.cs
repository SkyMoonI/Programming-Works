using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectable
{
	public int healthValue = 10;
	public void Collect()
	{
		Debug.Log("Health potion collected with value: " + healthValue);
	}
}
