using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodOverloading : MonoBehaviour
{
	Vector2D vector1;
	Vector2D vector2;
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("Area of a circle with radius 5: " + CalculateArea(5));
		Debug.Log("Area of a rectangle with length 10 and width 5: " + CalculateArea(10, 5));

		vector1 = new Vector2D(1, 2);
		vector2 = new Vector2D(3, 4);
		Vector2D vector3 = vector1 + vector2;
		Debug.Log("sum of two vectors: " + vector3);
	}

	float CalculateArea(float radius)
	{
		return Mathf.PI * (radius * radius);
	}

	float CalculateArea(float length, float width)
	{
		return length * width;
	}



}
