using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Model : only to store data 
public class Player4 : MonoBehaviour
{
	[Header("MVP References")]
	[SerializeField] HealthPresenter _healthPresenter;

	void Start()
	{
		_healthPresenter.OnDamage += HealthPresenter_OnDamage;
		_healthPresenter.OnHeal += HealthPresenter_OnHeal;
	}

	void HealthPresenter_OnDamage()
	{
		Debug.Log("Player4: OnDamage");
	}

	void HealthPresenter_OnHeal()
	{
		Debug.Log("Player4: OnHeal");
	}

	void OnDestroy()
	{
		_healthPresenter.OnDamage -= HealthPresenter_OnDamage;
		_healthPresenter.OnHeal -= HealthPresenter_OnHeal;
	}
}
