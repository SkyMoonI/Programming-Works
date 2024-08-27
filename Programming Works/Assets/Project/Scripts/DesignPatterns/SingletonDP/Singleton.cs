using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
	static T _instance;

	static bool _applicationIsQuitting = false;

	public static T GetInstance()
	{
		if (_applicationIsQuitting) { return null; }

		if (_instance == null)
		{
			_instance = FindAnyObjectByType<T>();

			if (_instance == null)
			{
				GameObject obj = new GameObject
				{
					name = typeof(T).Name
				};
				_instance = obj.AddComponent<T>();
			}
		}
		return _instance;
	}

	/* IMPORTANT!!! To use Awake in a derived class you need to do it this way
	 * protected override void Awake()
	 * {
	 *     base.Awake();
	 *     //Your code goes here
	 * }
	 * */

	protected virtual void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	void OnApplicationQuit()
	{
		_applicationIsQuitting = true;
	}
}
