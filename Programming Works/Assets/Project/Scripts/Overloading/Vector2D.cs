using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2D
{
	public float x;
	public float y;

	// constructor
	public Vector2D(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	// overload + operator. operator overloading must be static and public
	public static Vector2D operator +(Vector2D v1, Vector2D v2)
	{
		return new Vector2D(v1.x + v2.x, v1.y + v2.y);
	}

	// override ToString() method to print x and y values by the name of the variable 
	public override string ToString()
	{
		return "x: " + x + " y: " + y;
	}
}
