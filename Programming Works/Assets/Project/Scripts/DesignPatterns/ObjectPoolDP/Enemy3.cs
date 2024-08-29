using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : PoolableObject
{

	void Update()
	{
		if (transform.position.y < -15)
		{
			ReturnToPool();
		}
	}
}
