using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqInUnity : MonoBehaviour
{
	Transform[] enemies;
	// Start is called before the first frame update
	void Start()
	{
		Transform player = transform;

		Transform closestEnemy = enemies
		.OrderBy(enemy => Vector3.Distance(player.position, enemy.position))
		.FirstOrDefault();

		if (closestEnemy != null)
		{
			Debug.Log("Closest Enemy: " + closestEnemy.name);
		}
		else
		{
			Debug.Log("No enemies found");
		}
	}

}
