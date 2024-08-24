using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager2
{
	public event EventHandler OnGameOver;

	public void EndGame()
	{
		OnGameOver?.Invoke(this, EventArgs.Empty);
		Debug.Log("Game Over!");
	}
}
