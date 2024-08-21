using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControlSettings
{
	public float mouseSensitivity;
	public string keyBindings;

	// Parameterless constructor required for deserialization
	public ControlSettings() { }

	// Constructor
	public ControlSettings(float mouseSensitivity, string keyBindings)
	{
		this.mouseSensitivity = mouseSensitivity;
		this.keyBindings = keyBindings;
	}
}
