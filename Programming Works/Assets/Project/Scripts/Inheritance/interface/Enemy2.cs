using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour, IAttackable
{
	float _health = 100f;
	public float Health { get { return _health; } }

	public void TakeDamage(float damage)
	{
		_health -= damage;
		if (_health <= 0)
		{
			Die();
		}

	}

	void Die()
	{
		// Enemy death logic
	}

}
