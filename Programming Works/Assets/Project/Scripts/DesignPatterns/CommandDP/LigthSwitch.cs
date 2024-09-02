using System.Collections.Generic;

// Invoker
public class LigthSwitch
{
	// store the TurnOnCommand
	ICommand _onCommand;

	public LigthSwitch(ICommand onCommand)
	{
		_onCommand = onCommand;
	}

	public void TogglePower()
	{
		_onCommand.Execute();
	}
}
