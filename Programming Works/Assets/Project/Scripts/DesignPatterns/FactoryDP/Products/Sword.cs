using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
	public void Initialize()
	{
		Debug.Log("Sword initialized!");
	}

	public void Use()
	{
		Debug.Log("Sword slashes!");
	}
}
