using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel
{
	public event EventHandler<LevelUpEventArgs> OnLevelUp;

	int _level = 1;

	public void LevelUp()
	{
		_level++;
		OnLevelUp?.Invoke(this, new LevelUpEventArgs(_level));
	}
}

public class LevelUpEventArgs : EventArgs
{
	public int NewLevel { get; private set; }

	public LevelUpEventArgs(int newLevel)
	{
		NewLevel = newLevel;
	}
}