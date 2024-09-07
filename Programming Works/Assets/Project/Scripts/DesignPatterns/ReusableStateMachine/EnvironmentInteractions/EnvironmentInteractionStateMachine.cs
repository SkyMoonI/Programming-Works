using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging; // for the rigging constraint 
using UnityEngine.Assertions; // to be ensure the SerializeFields are not null

public class EnvironmentInteractionStateMachine : StateManager<EnvironmentInteractionStateMachine.EEnvironmentInteractionState>
{
	// this is for the StateManager's generic type
	public enum EEnvironmentInteractionState
	{
		Search,
		Approach,
		Rise,
		Touch,
		Reset
	}

	EnvironmentInteractionContext _context;

	[SerializeField] private TwoBoneIKConstraint _leftIKConstraint;
	[SerializeField] private TwoBoneIKConstraint _rightIKConstraint;
	[SerializeField] private MultiRotationConstraint _leftMultiRotationConstraint;
	[SerializeField] private MultiRotationConstraint _rightMultiRotationConstraint;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private CapsuleCollider _rootCollider;

	void Awake()
	{
		// to make sure the constraints are not null
		ValidateConstraints();

		// to initialize the EnvironmentInteractionContext
		_context = new EnvironmentInteractionContext(_leftIKConstraint, _rightIKConstraint,
		_leftMultiRotationConstraint, _rightMultiRotationConstraint, _rigidbody, _rootCollider, transform.root);

		// to instantiate the environment detection collider
		ConstructEnvironmentDetectionCollider();

		// to initialize the States
		InitializeStates();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		if (_context != null && _context.ClosestPointOnColliderFromShoulder != null)
		{
			Gizmos.DrawSphere(_context.ClosestPointOnColliderFromShoulder, .03f);
		}
	}

	// to make sure the constraints are not null
	private void ValidateConstraints()
	{
		Assert.IsNotNull(_leftIKConstraint, "Left IK constraint is not assigned");
		Assert.IsNotNull(_rightIKConstraint, "Right IK constraint is not assigned");
		Assert.IsNotNull(_leftMultiRotationConstraint, "Left Multi Rotation constraint is not assigned");
		Assert.IsNotNull(_rightMultiRotationConstraint, "Right Multi Rotation constraint is not assigned");
		Assert.IsNotNull(_rigidbody, "Rigidbody is not assigned");
		Assert.IsNotNull(_rootCollider, "Root collider is not assigned");
	}

	private void InitializeStates()
	{
		// Add States to inherited StateManager "States" dictionary and Set Initial State
		States.Add(EEnvironmentInteractionState.Reset, new ResetState(_context, EEnvironmentInteractionState.Reset));
		States.Add(EEnvironmentInteractionState.Search, new SearchState(_context, EEnvironmentInteractionState.Search));
		States.Add(EEnvironmentInteractionState.Approach, new ApproachState(_context, EEnvironmentInteractionState.Approach));
		States.Add(EEnvironmentInteractionState.Rise, new RiseState(_context, EEnvironmentInteractionState.Rise));
		States.Add(EEnvironmentInteractionState.Touch, new TouchState(_context, EEnvironmentInteractionState.Touch));

		// Set Initial State
		CurrentState = States[EEnvironmentInteractionState.Reset];
	}

	private void ConstructEnvironmentDetectionCollider()
	{
		// wingspan is roughly equal to the capsule collider's height
		float wingspan = _rootCollider.height;

		// instantiate the environment detection collider
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();

		// set the size of the environment detection collider
		boxCollider.size = new Vector3(wingspan, wingspan, wingspan);

		// set the center of the environment detection collider
		boxCollider.center = new Vector3(_rootCollider.center.x,
		_rootCollider.center.y + (.25f * wingspan), _rootCollider.center.z + (.5f * wingspan));

		// set the environment detection collider as a trigger
		boxCollider.isTrigger = true;

	}


}
