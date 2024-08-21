using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;


public class GameSettings
{
	// Dictionary to store all settings
	private Dictionary<string, object> _settings;

	public AudioSettings _audioSettings;
	public ControlSettings _controlSettings;
	public GraphicsSettings _graphicsSettings;

	public GameSettings()
	{
		_settings = new Dictionary<string, object>();
		SetDefaultSettings();
	}

	// Method to set a setting
	public void SetSettings<T>(string key, T value)
	{
		// Check if the setting(key) already exists
		if (_settings.ContainsKey(key))
		{
			_settings[key] = value;
		}
		else // If the setting(key) doesn't exist, add it
		{
			_settings.Add(key, value);
		}
	}

	// Method to get a setting, T is the type of the setting which can be any type
	public T GetSettings<T>(string key)
	{
		// Check if the setting(key) exists, and return its value
		if (_settings.ContainsKey(key))
		{
			if (_settings[key] is T value)
			{
				return value;
			}
			else
			{
				Debug.LogError($"Setting with key {key} is not of type {typeof(T).Name}");
				return default(T);
			}
		}
		else // If the setting(key) doesn't exist, return the default value
		{
			Debug.Log($"Setting with key {key} doesn't exist");
			return default(T);
		}
	}

	private void SetDefaultSettings()
	{
		_audioSettings = new AudioSettings(0.5f, 0.5f, 0.5f);
		_graphicsSettings = new GraphicsSettings(1920, 1080, true);
		_controlSettings = new ControlSettings(0.5f, "WASD");

		SetSettings("AudioSettings", _audioSettings);
		SetSettings("GraphicsSettings", _graphicsSettings);
		SetSettings("ControlSettings", _controlSettings);
	}

	// Method to save settings to a JSON file
	public void SaveSettings(string filePath)
	{
		// Convert dictionary to JSON
		string json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
		// Write JSON to file
		System.IO.File.WriteAllText(filePath, json);
	}

	// Method to load settings from a JSON file
	public void LoadSettings(string filePath)
	{
		if (System.IO.File.Exists(filePath))
		{
			// Read JSON from file
			string json = System.IO.File.ReadAllText(filePath);

			// Convert JSON to SerializableGameSettings class
			var deserializedSettings = JsonConvert.DeserializeObject<SerializableGameSettings>(json);

			// Set settings from deserialized class
			if (deserializedSettings != null)
			{
				_audioSettings = deserializedSettings.AudioSettings;
				_graphicsSettings = deserializedSettings.GraphicsSettings;
				_controlSettings = deserializedSettings.ControlSettings;

				SetSettings("AudioSettings", _audioSettings);
				SetSettings("GraphicsSettings", _graphicsSettings);
				SetSettings("ControlSettings", _controlSettings);
			}
		}
		else
		{
			Debug.Log("Settings file not found, loading defaults.");
		}
	}

	public void SetMasterVolume(float value)
	{
		var audioSettings = GetSettings<AudioSettings>("AudioSettings");
		audioSettings.masterVolume = value;
		SetSettings("AudioSettings", audioSettings);
	}

	public void SetMusicVolume(float value)
	{
		var audioSettings = GetSettings<AudioSettings>("AudioSettings");
		audioSettings.musicVolume = value;
		SetSettings("AudioSettings", audioSettings);
	}

	public void SetSFXVolume(float value)
	{
		var audioSettings = GetSettings<AudioSettings>("AudioSettings");
		audioSettings.sfxVolume = value;
		SetSettings("AudioSettings", audioSettings);
	}

	public void SetResolution(int width, int height)
	{
		var graphicsSettings = GetSettings<GraphicsSettings>("GraphicsSettings");
		graphicsSettings.resolutionWidth = width;
		graphicsSettings.resolutionHeight = height;
		SetSettings("GraphicsSettings", graphicsSettings);
	}

	public void SetFullScreen(bool value)
	{
		var graphicsSettings = GetSettings<GraphicsSettings>("GraphicsSettings");
		graphicsSettings.fullScreen = value;
		SetSettings("GraphicsSettings", graphicsSettings);
	}

	public void SetMouseSensitivity(float value)
	{
		var controlSettings = GetSettings<ControlSettings>("ControlSettings");
		controlSettings.mouseSensitivity = value;
		SetSettings("ControlSettings", controlSettings);
	}

	public void SetKeyBindings(string value)
	{
		var controlSettings = GetSettings<ControlSettings>("ControlSettings");
		controlSettings.keyBindings = value;
		SetSettings("ControlSettings", controlSettings);
	}

	// Method to print all settings to the console
	public void PrintSettings()
	{
		if (_settings.TryGetValue("AudioSettings", out var audioObj) && audioObj is AudioSettings audioSettings)
		{
			Debug.Log("Audio Settings:");
			Debug.Log("Master Volume: " + audioSettings.masterVolume);
			Debug.Log("Music Volume: " + audioSettings.musicVolume);
			Debug.Log("SFX Volume: " + audioSettings.sfxVolume);
		}

		if (_settings.TryGetValue("GraphicsSettings", out var graphicsObj) && graphicsObj is GraphicsSettings graphicsSettings)
		{
			Debug.Log("Graphics Settings:");
			Debug.Log("Resolution: " + graphicsSettings.resolutionWidth + "x" + graphicsSettings.resolutionHeight);
			Debug.Log("Full Screen: " + graphicsSettings.fullScreen);
		}

		if (_settings.TryGetValue("ControlSettings", out var controlObj) && controlObj is ControlSettings controlSettings)
		{
			Debug.Log("Control Settings:");
			Debug.Log("Mouse Sensitivity: " + controlSettings.mouseSensitivity);
			Debug.Log("Key Bindings: " + controlSettings.keyBindings);
		}
	}
}

// Class to store settings in a serializable format
public class SerializableGameSettings
{
	public AudioSettings AudioSettings { get; set; }
	public GraphicsSettings GraphicsSettings { get; set; }
	public ControlSettings ControlSettings { get; set; }
}