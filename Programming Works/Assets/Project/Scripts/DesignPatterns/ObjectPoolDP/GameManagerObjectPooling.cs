using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObjectPooling : MonoBehaviour
{
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private GameObject _projectilePrefab;

	private ObjectPool<PoolableObject> _enemyPool;
	private ObjectPool<PoolableObject> _projectilePool;

	private ObjectPool<PoolableObject> _enemyPoolManager;
	private ObjectPool<PoolableObject> _projectilePoolManager;
	GameObject enemy;
	GameObject projectile;
	// Start is called before the first frame update
	void Start()
	{
		_enemyPool = new ObjectPool<PoolableObject>(_enemyPrefab, 10, 5, transform, OnEnemyPulled, OnEnemyPushed);
		_projectilePool = new ObjectPool<PoolableObject>(_projectilePrefab, 10, 5, transform, OnProjectilePulled, OnProjectilePushed);

		// _enemyPoolManager = new ObjectPool<PoolableObject>(_enemyPrefab, 10, 5, transform, OnEnemyPulled, OnEnemyPushed);
		// _projectilePoolManager = new ObjectPool<PoolableObject>(_projectilePrefab, 10, 5, transform, OnProjectilePulled, OnProjectilePushed);

		// PoolManager.Instance.RegisterPool("EnemyPool", _enemyPoolManager);
		// PoolManager.Instance.RegisterPool("ProjectilePool", _projectilePoolManager);
	}


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Pull an enemy from the enemy pool
			enemy = _enemyPool.PullGameObject(transform.position);
			// Do something with the enemy
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			// Pull a projectile from the projectile pool
			projectile = _projectilePool.PullGameObject(transform.position);
			// Do something with the projectile
		}
	}

	private void OnEnemyPulled(PoolableObject enemy)
	{
		// Custom initialization for enemies
	}

	private void OnEnemyPushed(PoolableObject enemy)
	{
		// Custom cleanup for enemies
	}

	private void OnProjectilePulled(PoolableObject projectile)
	{
		// Custom initialization for projectiles
	}

	private void OnProjectilePushed(PoolableObject projectile)
	{
		// Custom cleanup for projectiles
	}
}
