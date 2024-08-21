using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GraphicsSettings
{
	public int resolutionWidth;
	public int resolutionHeight;
	public bool fullScreen;

	// Parameterless constructor required for deserialization
	public GraphicsSettings() { }

	// Constructor
	public GraphicsSettings(int resolutionWidth, int resolutionHeight, bool fullScreen)
	{
		this.resolutionWidth = resolutionWidth;
		this.resolutionHeight = resolutionHeight;
		this.fullScreen = fullScreen;
	}
}
