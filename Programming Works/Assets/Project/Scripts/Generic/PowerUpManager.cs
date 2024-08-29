using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager<T> where T : PowerUp
{
	List<T> _activePowerUps = new List<T>();

	public void ActivatePowerUp(T powerUp, GameObject player)
	{
		powerUp.Activate(player);
		_activePowerUps.Add(powerUp);
	}

	public void DeactivatePowerUp(T powerUp, GameObject player)
	{
		powerUp.Deactivate(player);
		_activePowerUps.Remove(powerUp);
	}

}
