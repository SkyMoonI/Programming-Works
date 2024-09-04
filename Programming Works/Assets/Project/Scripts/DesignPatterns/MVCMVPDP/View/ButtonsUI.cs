using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsUI : MonoBehaviour
{

	[Header("MVP References")]
	[SerializeField] HealthPresenter _healthPresenter;

	[Header("UI References")]
	[SerializeField] Button _damageButton;
	[SerializeField] Button _healButton;

	int _damageAmount = 10;
	int _healAmount = 10;

	void Awake()
	{
		_damageButton.onClick.AddListener(() =>
		{
			_healthPresenter.OnDamageButtonClicked(_damageAmount);
		});

		_healButton.onClick.AddListener(() =>
		{
			_healthPresenter.OnHealButtonClicked(_healAmount);
		});

	}
}
