using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetState : EnvironmentInteractionState
{
	public ResetState(EnvironmentInteractionContext context,
	EnvironmentInteractionStateMachine.EEnvironmentInteractionState stateKey) : base(context, stateKey)
	{
		EnvironmentInteractionContext Context = context;
	}

	public override void EnterState()
	{
		Debug.Log("Entering Reset State");
	}

	public override void UpdateState()
	{
		Debug.Log("Updating Reset State");
	}

	public override void ExitState()
	{
	}

	public override EnvironmentInteractionStateMachine.EEnvironmentInteractionState GetNextState()
	{
		return EnvironmentInteractionStateMachine.EEnvironmentInteractionState.Search;
		// return StateKey;
	}

	public override void OnTriggerEnter(Collider other)
	{
	}

	public override void OnTriggerExit(Collider other)
	{
	}

	public override void OnTriggerStay(Collider other)
	{
	}


}
