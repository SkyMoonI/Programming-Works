using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour
{
	// current ligthbulb state
	bool isPowerOn = false;
	public string Color { get; set; }

	public void TogglePower()
	{
		if (!isPowerOn)
		{
			Debug.Log("Lightbulb turned on");
		}
		else
		{
			Debug.Log("Lightbulb turned off");
		}
		isPowerOn = !isPowerOn;
	}

	public void SetLightColor(string newColor)
	{
		this.Color = newColor;
		Debug.Log("Lightbulb color changed to: " + newColor);
	}
	public void SetRandomLightColor()
	{
		string[] colors = { "Red", "Green", "Blue" };
		string randomColor = colors[Random.Range(0, colors.Length)];
		this.Color = randomColor;
		Debug.Log("Random lightbulb color: " + Color);
	}
}
