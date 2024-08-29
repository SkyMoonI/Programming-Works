using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGeneric : MonoBehaviour
{
	private PowerUpManager<PowerUp> powerUpManager;

	void Start()
	{
		powerUpManager = new PowerUpManager<PowerUp>();
	}

	void OnTriggerEnter(Collider other)
	{
		PowerUp powerUp = other.GetComponent<PowerUp>();
		if (powerUp != null)
		{
			powerUpManager.ActivatePowerUp(powerUp, this.gameObject);
			StartCoroutine(DeactivatePowerUpAfterDuration(powerUp));
		}
	}

	private IEnumerator DeactivatePowerUpAfterDuration(PowerUp powerUp)
	{
		yield return new WaitForSeconds(powerUp.duration);
		powerUpManager.DeactivatePowerUp(powerUp, this.gameObject);
	}

}
