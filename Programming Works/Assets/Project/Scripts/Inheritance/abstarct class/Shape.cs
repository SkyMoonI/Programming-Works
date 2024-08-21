using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
	public Color color;

	public abstract float CalculateArea();
	public abstract float CalculatePerimeter();

	public virtual void DisplayInfo()
	{
		Debug.Log("Shape color: " + color);
	}
}

public class Circle : Shape
{
	public float radius;
	public override float CalculateArea()
	{
		return Mathf.PI * (radius * radius);
	}
	public override float CalculatePerimeter()
	{
		return 2 * Mathf.PI * radius;
	}
}

public class Rectangle : Shape
{
	public float length;
	public float width;

	public override float CalculateArea()
	{
		return length * width; // Override
	}

	public override float CalculatePerimeter()
	{
		return 2 * (length + width);
	}

}