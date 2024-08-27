using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IEnemy
{
	public void Initialize()
	{
		Debug.Log("Robot initialized!");
	}
	public void Attack()
	{
		Debug.Log("Robot attacks!");
	}

}
