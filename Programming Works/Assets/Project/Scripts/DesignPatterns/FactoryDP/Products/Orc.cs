using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour, IEnemy
{
	public void Initialize()
	{
		Debug.Log("Orc initialized!");
	}

	public void Attack()
	{
		Debug.Log("Orc attacks!");
	}
}

