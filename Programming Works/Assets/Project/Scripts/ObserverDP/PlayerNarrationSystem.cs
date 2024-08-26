using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarrationSystem : MonoBehaviour, IObserver
{
	[SerializeField] Subject _playerSubject;
	Dictionary<PlayerActions, Action> _playerActionHandlers;

	// add some other components here like audio, animation, etc. 


	void Awake()
	{
		_playerActionHandlers = new Dictionary<PlayerActions, Action>()
		{
			{PlayerActions.Jump, HandleJump},
			{PlayerActions.Die, HandleDie},
			{PlayerActions.CollectItem, HandleCollectItem},
			{PlayerActions.Attack, HandleAttack}
		};
	}

	void OnEnable()
	{
		_playerSubject.AddObserver(this);
	}
	void OnDisable()
	{
		_playerSubject.RemoveObserver(this);
	}

	public void OnNotify(PlayerActions action)
	{
		if (_playerActionHandlers.ContainsKey(action))
		{
			_playerActionHandlers[action]();
		}

	}

	void HandleJump()
	{
		// code to handle jump, like an animation, audio, etc.
		Debug.Log("Player Narration system has been notified! Player has jumped");
	}

	void HandleDie()
	{
		// code to handle die, like an animation, audio, etc.
		Debug.Log("Player Narration system has been notified! Player has died");
	}

	private void HandleAttack()
	{
		// code to handle attack, like an animation, audio, etc.
		Debug.Log("Player Narration system has been notified! Player has attacked");
	}

	private void HandleCollectItem()
	{
		// code to handle collect item, like an animation, audio, etc.
		Debug.Log("Player Narration system has been notified! Player has collected item");
	}

}
