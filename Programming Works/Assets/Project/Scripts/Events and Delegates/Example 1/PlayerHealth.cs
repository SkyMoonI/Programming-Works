using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	// define an event using the action delegate
	public event Action OnPlayerDamaged;


	// define another event using EventHandler (with no custom event data)
	public event EventHandler OnPlayerDied;

	private int _health = 100;

	public void TakeDamage(int damageAmount)
	{
		_health -= damageAmount;

		// trigger the player OnPlayerDamaged event
		OnPlayerDamaged?.Invoke();

		if (_health <= 0)
		{
			// trigger the OnPlayerDied event
			OnPlayerDied?.Invoke(this, EventArgs.Empty);
		}
	}
}
