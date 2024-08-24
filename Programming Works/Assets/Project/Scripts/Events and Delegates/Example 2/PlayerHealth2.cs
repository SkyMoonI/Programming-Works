using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create delegate
public delegate int HealDelegate(int currentHealth, int healAmount);

public class PlayerHealth2
{
	// create delegate variable
	public HealDelegate OnHeal;

	int _currentHealth = 50;

	public void Heal(int healAmount)
	{
		if (OnHeal != null)
		{
			_currentHealth = OnHeal(_currentHealth, healAmount);
			Debug.Log("Healed! Current Health: " + _currentHealth);
		}
	}
}
