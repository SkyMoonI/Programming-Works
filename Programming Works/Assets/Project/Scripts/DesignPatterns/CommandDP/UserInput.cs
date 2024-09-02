using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	[SerializeField] Lightbulb _lightbulb;
	LightApp _lightApp;

	// Start is called before the first frame update
	void Start()
	{
		// setup invoker
		_lightApp = new LightApp();

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ICommand togglePowerCommand = new TogglePowerCommand(_lightbulb);
			_lightApp.AddCommand(togglePowerCommand);
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			ICommand changeColorCommand = new ChangeColorCommand(_lightbulb);
			_lightApp.AddCommand(changeColorCommand);
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			_lightApp.UndoCommand();
		}
	}
}
