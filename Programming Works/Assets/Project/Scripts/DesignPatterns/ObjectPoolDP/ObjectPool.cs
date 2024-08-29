using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
{
	private Queue<T> _pooledObjects;
	private GameObject _prefab;
	private Transform _parentTransform;
	private int _expandAmount;
	private int _initialPoolSize;
	private Action<T> _onPull;
	private Action<T> _onPush;

	public int PooledCount => _pooledObjects.Count;

	public ObjectPool(GameObject prefab, int initialPoolSize = 10, int expandAmount = 5,
	 Transform parentTransform = null, Action<T> onPull = null, Action<T> onPush = null)
	{
		_pooledObjects = new Queue<T>(initialPoolSize);
		_prefab = prefab;
		_parentTransform = parentTransform;
		_expandAmount = expandAmount;
		_initialPoolSize = initialPoolSize;
		_onPull = onPull;
		_onPush = onPush;

		Spawn(_initialPoolSize);
	}


	/// <summary>
	/// Pulls an object from the pool, or expands the pool and pulls a new object if the pool is empty.
	/// </summary>
	/// <returns>The pulled object, with its Initialize method called and IsActive set to true.</returns>
	public T Pull()
	{
		T obj;

		if (_pooledObjects.Count > 0)
		{
			obj = _pooledObjects.Dequeue(); // Get the first object from the queue
		}
		else
		{
			obj = ExpandPool(_expandAmount); // Expand the pool if necessary
		}

		obj.gameObject.SetActive(true); //ensure the object is on
		obj.Initialize(Push);

		//allow default behavior and turning object back on
		_onPull?.Invoke(obj);

		return obj;
	}

	public T Pull(Vector3 position)
	{
		T t = Pull();
		t.transform.position = position;
		return t;
	}

	public T Pull(Vector3 position, Quaternion rotation)
	{
		T t = Pull();
		t.transform.position = position;
		t.transform.rotation = rotation;
		return t;
	}

	/// <summary>
	/// Pushes an object back into the pool, disabling its game object and adding it to the end of the queue.
	/// </summary>
	/// <param name="obj">The object to push.</param>
	public void Push(T obj)
	{
		_onPush?.Invoke(obj);
		obj.gameObject.SetActive(false);
		_pooledObjects.Enqueue(obj); // Add the object to the end of the queue
	}

	private void Spawn(int count)
	{
		for (int i = 0; i < count; i++)
		{
			T obj = GameObject.Instantiate(_prefab).GetComponent<T>();
			if (_parentTransform != null)
			{
				obj.transform.SetParent(_parentTransform); // Set the parent to keep hierarchy clean
			}
			obj.gameObject.SetActive(false);
			_pooledObjects.Enqueue(obj); // Add to the queue
		}
	}
	private T ExpandPool(int expandAmount)
	{
		// Optionally log or handle the fact that the pool had to be expanded
		Spawn(expandAmount); // _expandAmount size to grow the pool
		return _pooledObjects.Dequeue();
	}

	public GameObject PullGameObject()
	{
		return Pull().gameObject;
	}

	public GameObject PullGameObject(Vector3 position)
	{
		GameObject obj = Pull().gameObject;
		obj.transform.position = position;
		return obj;
	}

	public GameObject PullGameObject(Vector3 position, Quaternion rotation)
	{
		GameObject obj = Pull().gameObject;
		obj.transform.position = position;
		obj.transform.rotation = rotation;
		return obj;
	}
}
