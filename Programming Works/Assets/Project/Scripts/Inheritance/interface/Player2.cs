using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour, IAttackable
{
	float _health = 100f;
	public float Health { get { return _health; } }

	float _damage = 10f;
	public float Damage { get { return _damage; } }

	float _armor = 10f;
	public float Armor { get { return _armor; } }

	public void TakeDamage(float damageAmount)
	{
		float reducedDamage = damageAmount - (_armor * _armor / 100);
		_health -= reducedDamage;
		if (_health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		// Player death logic
	}

	public void Attack(IAttackable target, float damageAmount)
	{
		target.TakeDamage(damageAmount);
	}

	public void CollectItem(ICollectable item)
	{
		item.Collect();
	}
}
