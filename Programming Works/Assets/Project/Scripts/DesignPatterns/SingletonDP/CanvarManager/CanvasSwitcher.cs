using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
	public CanvasType _desiredCanvasType;

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
		_canvasManager.SwitchCanvas(_desiredCanvasType);
	}
}
