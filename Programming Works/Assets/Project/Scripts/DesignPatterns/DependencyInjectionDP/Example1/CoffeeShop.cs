using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeShop : MonoBehaviour
{
	ICoffeeMachine _espressoMachine = new EspressoMachine();
	ICoffeeMachine _dripCoffeMachine = new DripCoffeeMachine();

	Barista _barista;
	Barista _barista2;

	// Start is called before the first frame update
	void Start()
	{
		_barista = new Barista(_espressoMachine);
		_barista2 = new Barista(_dripCoffeMachine);

		_barista.MakeCoffee();
		_barista2.MakeCoffee();
	}
}
