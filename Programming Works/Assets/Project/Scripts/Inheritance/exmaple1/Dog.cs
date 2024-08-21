using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// derived class
public class Dog : Animal
{
	public override void MakeSound()
	{
		Debug.Log("Dog barks");
	}
}
