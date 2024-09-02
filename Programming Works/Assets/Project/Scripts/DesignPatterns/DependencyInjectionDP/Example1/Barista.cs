using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barista
{
	private ICoffeeMachine _coffeeMachine;

	public Barista(ICoffeeMachine coffeeMachine)
	{
		_coffeeMachine = coffeeMachine;  // The barista chooses an espresso machine
	}
	public void MakeCoffee()
	{
		_coffeeMachine.Brew();
		Debug.Log("Serving coffee...");
	}
}
