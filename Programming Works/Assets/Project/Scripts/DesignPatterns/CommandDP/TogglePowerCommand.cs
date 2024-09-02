// Concrete Command  
public class TogglePowerCommand : ICommand
{
	// store reference to receiver
	Lightbulb _lightbulb;

	// constructor to store lightbulb reference
	public TogglePowerCommand(Lightbulb lightbulb)
	{
		_lightbulb = lightbulb;
	}

	// execute the stored command
	public void Execute()
	{
		_lightbulb.TogglePower();
	}

	public void Undo()
	{
		_lightbulb.TogglePower();
	}
}
