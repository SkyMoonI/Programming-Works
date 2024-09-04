using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public event Action OnHealthChanged;

	const int MAX_HEALTH = 100;
	const int MIN_HEALTH = 0;
	int _currentHealth;

	public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
	public int MaxHealth { get { return MAX_HEALTH; } }
	public int MinHealth { get { return MIN_HEALTH; } }

	public void IncreaseHealth(int amount)
	{
		_currentHealth += amount;
		if (_currentHealth > MAX_HEALTH)
		{
			_currentHealth = MAX_HEALTH;
		}

		OnHealthChanged?.Invoke();
	}

	public void DecreaseHealth(int amount)
	{
		_currentHealth -= amount;
		if (_currentHealth < MIN_HEALTH)
		{
			_currentHealth = MIN_HEALTH;
		}
		OnHealthChanged?.Invoke();
	}
}
