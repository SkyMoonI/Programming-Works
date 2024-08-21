using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	float _attackDamage;

	public override void TakeDamage(float damageAmount)
	{
		// Additional logic for player taking damage
		// ...

		base.TakeDamage(damageAmount); // Call base class implementation
	}
}
