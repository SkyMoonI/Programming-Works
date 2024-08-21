using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioSettings
{
	public float masterVolume;
	public float musicVolume;
	public float sfxVolume;

	// Parameterless constructor required for deserialization
	public AudioSettings() { }

	// Constructor
	public AudioSettings(float masterVolume, float musicVolume, float sfxVolume)
	{
		this.masterVolume = masterVolume;
		this.musicVolume = musicVolume;
		this.sfxVolume = sfxVolume;
	}
}
