using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// derived class
public class Cat : Animal
{
	public override void MakeSound()
	{
		Debug.Log("Cat meows");
	}
}
