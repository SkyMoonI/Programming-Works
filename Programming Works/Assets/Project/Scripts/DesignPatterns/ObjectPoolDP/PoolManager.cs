using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	public static PoolManager Instance { get; private set; }
	private Dictionary<string, IPool<PoolableObject>> _pools = new Dictionary<string, IPool<PoolableObject>>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); // Persist across scenes
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Register a new pool
	public void RegisterPool(string poolId, IPool<PoolableObject> pool)
	{
		if (!_pools.ContainsKey(poolId))
		{
			_pools.Add(poolId, pool);
		}
	}

	// Retrieve an object from the specified pool
	public PoolableObject GetObjectFromPool(string poolId)
	{
		if (_pools.ContainsKey(poolId))
		{
			return _pools[poolId].Pull();
		}

		Debug.LogWarning($"Pool with ID {poolId} not found.");
		return null;
	}

	// Retrieve an object from the specified pool at a position
	public PoolableObject GetObjectFromPool(string poolId, Vector3 position)
	{
		if (_pools.ContainsKey(poolId))
		{
			PoolableObject obj = _pools[poolId].Pull();
			obj.transform.position = position;
			return obj;
		}

		Debug.LogWarning($"Pool with ID {poolId} not found.");
		return null;
	}

	// Retrieve an object from the specified pool at a position and rotation
	public PoolableObject GetObjectFromPool(string poolId, Vector3 position, Quaternion rotation)
	{
		if (_pools.ContainsKey(poolId))
		{
			PoolableObject obj = _pools[poolId].Pull();
			obj.transform.position = position;
			obj.transform.rotation = rotation;
			return obj;
		}

		Debug.LogWarning($"Pool with ID {poolId} not found.");
		return null;
	}

	// Return an object to the specified pool
	public void ReturnObjectToPool(string poolId, PoolableObject obj)
	{
		if (_pools.ContainsKey(poolId))
		{
			_pools[poolId].Push(obj);
		}
		else
		{
			Debug.LogWarning($"Pool with ID {poolId} not found.");
			Destroy(obj); // Fallback if no pool is found
		}
	}
}
