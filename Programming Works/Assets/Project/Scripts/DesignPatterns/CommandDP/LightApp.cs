
using System.Collections.Generic;

public class LightApp
{
	Stack<ICommand> _commandList;


	public LightApp()
	{
		_commandList = new Stack<ICommand>();
	}

	public void AddCommand(ICommand command)
	{
		command.Execute();
		_commandList.Push(command);
	}

	public void UndoCommand()
	{
		if (_commandList.Count > 0)
		{
			ICommand latestCommand = _commandList.Pop();
			latestCommand.Undo();
		}
	}
}
