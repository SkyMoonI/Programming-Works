using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
	public int value = 1;

	public void Collect()
	{
		Debug.Log("Coin collected with value: " + value);
	}
}
