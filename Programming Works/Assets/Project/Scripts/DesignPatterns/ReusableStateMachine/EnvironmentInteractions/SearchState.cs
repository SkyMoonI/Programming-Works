using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : EnvironmentInteractionState
{
	public SearchState(EnvironmentInteractionContext context,
	EnvironmentInteractionStateMachine.EEnvironmentInteractionState stateKey) : base(context, stateKey)
	{
		EnvironmentInteractionContext Context = context;
	}

	public override void EnterState()
	{
		Debug.Log("Entering Search State");
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override EnvironmentInteractionStateMachine.EEnvironmentInteractionState GetNextState()
	{
		return StateKey;
	}

	public override void OnTriggerEnter(Collider other)
	{
		StartIkTargetPositionTracking(other);
	}

	public override void OnTriggerStay(Collider other)
	{

		UpdateIkTargetPosition(other);
	}

	public override void OnTriggerExit(Collider other)
	{
		ResetIkTargetPositionTracking(other);
	}



}
