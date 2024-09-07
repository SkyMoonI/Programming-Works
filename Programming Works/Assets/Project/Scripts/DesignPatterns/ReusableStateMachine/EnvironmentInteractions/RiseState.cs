using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseState : EnvironmentInteractionState
{
	public RiseState(EnvironmentInteractionContext context,
	EnvironmentInteractionStateMachine.EEnvironmentInteractionState stateKey) : base(context, stateKey)
	{
		EnvironmentInteractionContext Context = context;
	}

	public override void EnterState()
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
	}

	public override void OnTriggerExit(Collider other)
	{
	}

	public override void OnTriggerStay(Collider other)
	{
	}

	public override void UpdateState()
	{
	}
}
