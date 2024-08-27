using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour, IWeapon
{
	public void Initialize()
	{
		Debug.Log("Laser Gun initialized!");
	}

	public void Use()
	{
		Debug.Log("Laser Gun fires!");
	}
}
