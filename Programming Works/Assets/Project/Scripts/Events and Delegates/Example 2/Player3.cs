using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3
{
	public Action<int, int> OnHealAction;

	public void Heal(int currentHealth, int healAmount)
	{
		OnHealAction?.Invoke(currentHealth, healAmount);
	}


}

