using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerFactoryDP : MonoBehaviour
{
	[SerializeField] Factory[] _factories;

	Factory _gameFactory;


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnEnemy();
		}
	}

	void SpawnEnemy()
	{
		_gameFactory = _factories[Random.Range(0, _factories.Length)];
		var randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
		_gameFactory.CreateEnemy(randomPosition);
		_gameFactory.CreateWeapon(randomPosition + new Vector3(0, 1, 0));
	}

}
