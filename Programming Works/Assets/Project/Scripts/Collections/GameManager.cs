using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	GameSettings _gameSettings;
	string settingsFilePath;

	// Start is called before the first frame update
	void Start()
	{
		settingsFilePath = Application.persistentDataPath + "/game_settings.json";
		_gameSettings = new GameSettings();

		_gameSettings.PrintSettings();

		// Load settings from file
		_gameSettings.LoadSettings(settingsFilePath);

		Debug.Log("------------------------");

		// Print settings to console
		_gameSettings.PrintSettings();

		// Debug.Log("------------------------");

		// Example of modifying individual settings
		// _gameSettings.SetMasterVolume(0.7f);
		// _gameSettings.SetMusicVolume(0.7f);
		// _gameSettings.SetSFXVolume(0.7f);
		// _gameSettings.SetResolution(1280, 720);
		// _gameSettings.SetFullScreen(false);
		// _gameSettings.SetMouseSensitivity(1.2f);
		// _gameSettings.SetKeyBindings("WASDQERTY");

		// Print settings to console
		// _gameSettings.PrintSettings();

		// Save settings when done modifying
		_gameSettings.SaveSettings(settingsFilePath);
	}

	void OnApplicationQuit()
	{
		// Save settings when the game closes
		_gameSettings.SaveSettings(settingsFilePath);
	}
}
