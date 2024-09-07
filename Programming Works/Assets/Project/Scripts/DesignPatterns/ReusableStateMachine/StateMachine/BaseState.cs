using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
	protected BaseState(EState stateKey)
	{
		StateKey = stateKey;
	}

	public EState StateKey { get; private set; }

	public abstract void EnterState();
	public abstract void UpdateState();
	public abstract void ExitState();
	public abstract EState GetNextState();
	public abstract void OnTriggerEnter(Collider other);
	public abstract void OnTriggerStay(Collider other);
	public abstract void OnTriggerExit(Collider other);

}
