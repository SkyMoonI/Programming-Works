using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
	START_GAME,
	KILL_PLAYER
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
	public ButtonType _buttonType;

	CanvasManager _canvasManager;
	Button _menuButton;

	void Start()
	{
		_menuButton = GetComponent<Button>();
		_menuButton.onClick.AddListener(OnButtonClicked);
		_canvasManager = CanvasManager.GetInstance();
	}

	void OnButtonClicked()
	{
		switch (_buttonType)
		{
			case ButtonType.START_GAME:
				//Call other code that is necessary to start the game like levelManager.StartGame()
				_canvasManager.SwitchCanvas(CanvasType.GameUI);
				break;
			case ButtonType.KILL_PLAYER:
				//Do More Things like SaveSystem.Save()
				_canvasManager.SwitchCanvas(CanvasType.EndScreen);
				break;
			default:
				Debug.LogError("The button type not found: " + _buttonType);
				break;
		}
	}
}
