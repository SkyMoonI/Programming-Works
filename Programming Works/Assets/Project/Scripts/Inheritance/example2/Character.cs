using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Character : MonoBehaviour
{
	float _health;
	float _speed;

	public float Health { get => _health; set => _health = value; }
	public float Speed { get => _speed; set => _speed = value; }

	public virtual void TakeDamage(float damage)
	{
		_health -= damage;
	}
}
