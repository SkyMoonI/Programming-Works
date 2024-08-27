using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FantasyFactory : Factory
{
	[SerializeField] Orc _orcPrefab;
	[SerializeField] Sword _swordPrefab;

	public override IEnemy CreateEnemy(Vector3 position)
	{
		GameObject orcInstance = Instantiate(_orcPrefab.gameObject, position, Quaternion.identity);
		Orc newOrc = orcInstance.GetComponent<Orc>();

		newOrc.Initialize();
		newOrc.Attack();

		return newOrc;
	}

	public override IWeapon CreateWeapon(Vector3 position)
	{
		GameObject swordInstance = Instantiate(_swordPrefab.gameObject, position, Quaternion.identity);
		Sword newSword = swordInstance.GetComponent<Sword>();

		newSword.Initialize();
		newSword.Use();

		return newSword;
	}
}
