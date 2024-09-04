using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
	public event Action OnDamage;
	public event Action OnHeal;


	[Header("Model")]
	[SerializeField] Health _health;

	[Header("View")]
	[SerializeField] Slider _healthSlider;

	void Start()
	{
		_health.OnHealthChanged += Health_OnHealthChanged;

		_health.CurrentHealth = _health.MaxHealth;
		_healthSlider.value = 1f;
	}

	void Health_OnHealthChanged()
	{
		UpdateView();
	}

	public void UpdateView()
	{
		if (_health == null) { return; }

		if (_healthSlider != null && _health.MaxHealth != 0)
		{
			float targetValue = (float)_health.CurrentHealth / _health.MaxHealth;
			Debug.Log(_health.CurrentHealth);
			_healthSlider.value = targetValue;
		}
	}

	public void OnDamageButtonClicked(int amount)
	{
		_health?.DecreaseHealth(amount);

		OnDamage?.Invoke();
	}

	public void OnHealButtonClicked(int amount)
	{
		_health?.IncreaseHealth(amount);

		OnHeal?.Invoke();
	}

	void OnDestroy()
	{
		_health.OnHealthChanged -= Health_OnHealthChanged;
	}
}
