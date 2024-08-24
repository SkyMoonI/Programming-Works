using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] private PlayerHealth _playerHealth;

	void OnEnable()
	{
		// Subscribe to the player's events
		_playerHealth.OnPlayerDamaged += UpdateHealthUI;
		_playerHealth.OnPlayerDied += ShowGameOverScreen;
	}

	void OnDisable()
	{
		// Unsubscribe from the player's events
		_playerHealth.OnPlayerDamaged -= UpdateHealthUI;
		_playerHealth.OnPlayerDied -= ShowGameOverScreen;
	}

	public void UpdateHealthUI()
	{
		Debug.Log("Player took damage! Updating health UI.");
		// Code to update the health UI goes here
	}

	public void ShowGameOverScreen(object sender, EventArgs e)
	{
		Debug.Log("Player died! Showing Game Over screen.");
		// Code to show the Game Over screen goes here
	}

}
