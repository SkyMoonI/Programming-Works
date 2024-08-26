using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum CanvasType
{
	MainMenu,
	GameUI,
	EndScreen
}

public class CanvasManager : Singleton<CanvasManager>
{
	List<CanvasController> _canvasControllerList;
	CanvasController _lastActiveCanvas;

	protected override void Awake()
	{
		// Call base class implementation for singleton.
		base.Awake();

		// Get all canvas controllers in the scene, but can't convert it to list.
		// So we use Linq.
		_canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();

		// Set all canvas controllers to inactive by default.
		_canvasControllerList.ForEach((canvasController) =>
		{
			// Set canvas controller to inactive.
			canvasController.gameObject.SetActive(false);
		});

		// Set main menu canvas to active by default.
		SwitchCanvas(CanvasType.MainMenu);

	}

	public void SwitchCanvas(CanvasType canvasType)
	{
		if (_lastActiveCanvas != null)
		{
			_lastActiveCanvas.gameObject.SetActive(false);
		}

		CanvasController desiredCanvas = _canvasControllerList.Find((canvasController) => canvasController.canvasType == canvasType);
		if (desiredCanvas != null)
		{
			desiredCanvas.gameObject.SetActive(true);
			_lastActiveCanvas = desiredCanvas;
		}
		else
		{
			Debug.LogError("The desired canvas not found: " + canvasType);
		}

	}
}
