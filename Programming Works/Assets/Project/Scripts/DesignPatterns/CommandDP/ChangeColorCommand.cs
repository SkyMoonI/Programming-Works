// Concrete Command
using UnityEngine;

public class ChangeColorCommand : ICommand
{
	// store lightbulb receiver 
	Lightbulb _lightbulb;

	// store previous lightbulb color
	string _previousColor;

	public ChangeColorCommand(Lightbulb lightbulb)
	{
		_lightbulb = lightbulb;
	}
	public void Execute()
	{
		_lightbulb.SetRandomLightColor();
		_previousColor = _lightbulb.Color;
	}

	public void Undo()
	{
		_lightbulb.SetLightColor(_previousColor);
	}
}
