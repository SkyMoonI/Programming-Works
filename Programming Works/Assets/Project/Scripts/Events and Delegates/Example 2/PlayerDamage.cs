using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage
{
	public event Action OnPlayerDamaged;

	int _health = 100;

	public void TakeDamage(int damageAmount)
	{
		_health -= damageAmount;

		OnPlayerDamaged?.Invoke();

		Debug.Log("Player took damage! Health is now: " + _health);
	}
}
