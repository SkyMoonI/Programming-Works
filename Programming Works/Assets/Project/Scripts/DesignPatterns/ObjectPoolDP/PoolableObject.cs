using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolable<PoolableObject>
{
	public Action<PoolableObject> _returnToPool;
	private void OnDisable()
	{
		ReturnToPool();
	}
	public void Initialize(Action<PoolableObject> returnAction)
	{
		_returnToPool = returnAction;
	}

	public void ReturnToPool()
	{
		_returnToPool?.Invoke(this);
	}

}
