using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem
{
	public Func<int, int, int> CalculateDamage;

	public void PerformAttack(int baseDamage, int armor)
	{
		int finalDamage = CalculateDamage?.Invoke(baseDamage, armor) ?? 0;
		Debug.Log("Final Damage: " + finalDamage);
	}
}
