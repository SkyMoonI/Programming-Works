using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class
public class Animal
{
	protected string _name;

	public virtual void MakeSound()
	{
		Debug.Log("Animal makes a Sound");
	}
}
