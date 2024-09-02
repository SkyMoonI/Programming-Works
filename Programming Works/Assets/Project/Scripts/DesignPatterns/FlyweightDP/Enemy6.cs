using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour
{
	[SerializeField] EnemyData _enemyData;
	float _currentHealth;

	// Start is called before the first frame update
	void Start()
	{
		_currentHealth = _enemyData._maxHealth;
		Debug.Log("Enemy6 created");
		Debug.Log("Current Health: " + _currentHealth);
		Debug.Log("Max Health: " + _enemyData._maxHealth);
		Debug.Log("Max Speed: " + _enemyData._maxSpeed);
		Debug.Log("Attack Damage: " + _enemyData._attackDamage);
		Debug.Log("Attack Speed: " + _enemyData._attackSpeed);
		Debug.Log("Attack Range: " + _enemyData._attackRange);
	}

}
