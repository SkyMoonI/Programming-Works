using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExceptionHandling : MonoBehaviour
{
	public GameObject player;
	int[] numbers = { 1, 2, 3 };


	void Start()
	{
		// Basics of Exception Handling
		try
		{
			Debug.Log(numbers[3]);
		}
		catch (Exception ex)
		{
			Debug.LogError("An error occurred: " + ex.Message);
		}
		finally
		{
			Debug.Log("This will always execute.");
		}

		// Common Exceptions in Unity
		// NullReferenceException
		try
		{
			Debug.Log(player.name);
		}
		catch (NullReferenceException ex)
		{
			Debug.LogError("Player object is not assigned: " + ex.Message);
		}

		// IndexOutOfRangeException
		try
		{
			Debug.Log(numbers[3]);
		}
		catch (IndexOutOfRangeException ex)
		{
			Debug.LogError("Array index out of range: " + ex.Message);
		}

		// ArgumentException
		try
		{
			CreateEnemy(-5);
		}
		catch (ArgumentException ex)
		{
			Debug.LogError("Invalid argument: " + ex.Message);
		}


	}
	void CreateEnemy(int numberOfEnemies)
	{
		if (numberOfEnemies < 0)
		{
			throw new ArgumentException("Number of enemies must be greater than 0");
		}
	}


}
