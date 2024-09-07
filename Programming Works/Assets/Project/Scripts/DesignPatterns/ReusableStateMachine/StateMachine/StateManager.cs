using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
	// stores all the concrete states of the state machine
	// only classes that should have access to this dictionary are those inheriting from this class
	// so it is protected
	protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
	protected BaseState<EState> CurrentState;

	protected bool _isTransitioning = false;

	void Start()
	{
		CurrentState.EnterState();
	}
	void Update()
	{
		// if the current state is not the same as the next state, transition to the next state
		EState nextStateKey = CurrentState.GetNextState();
		if (!_isTransitioning && nextStateKey.Equals(CurrentState.StateKey)) // check if the state machine is transitioning to a new state
		{
			CurrentState.UpdateState();
		}
		else if (!_isTransitioning) // check if the state machine is transitioning to a new state
		{
			TransitionToState(nextStateKey);
		}

	}

	/// <summary>
	/// Transition to a new state.
	/// </summary>
	/// <param name="nextStateKey">The enum key of the next state.</param>
	/// <remarks>
	/// This method will call the <see cref="BaseState.ExitState"/> method of the current state,
	/// set the current state to the new state, and then call the <see cref="BaseState.EnterState"/>
	/// method of the new state.
	/// </remarks>
	public void TransitionToState(EState nextStateKey)
	{
		// set transitioning flag to true to prevent the state machine from transitioning to the same state
		_isTransitioning = true;

		// call the exit method of the current state to clean up the previous state
		CurrentState.ExitState();
		// set the current state to the new state
		CurrentState = States[nextStateKey];
		// call the enter method of the new state
		CurrentState.EnterState();

		// set transitioning flag to false to allow the state machine to transition to the next state
		_isTransitioning = false;
	}

	void OnTriggerEnter(Collider other)
	{
		CurrentState.OnTriggerEnter(other);
	}
	void OnTriggerStay(Collider other)
	{
		CurrentState.OnTriggerStay(other);
	}
	void OnTriggerExit(Collider other)
	{
		CurrentState.OnTriggerExit(other);
	}
}
