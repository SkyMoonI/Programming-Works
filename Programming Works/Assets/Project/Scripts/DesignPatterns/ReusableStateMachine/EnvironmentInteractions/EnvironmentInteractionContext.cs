using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnvironmentInteractionContext
{
	public enum EBodySide
	{
		LEFT,
		RIGHT
	}

	private TwoBoneIKConstraint _leftIKConstraint;
	private TwoBoneIKConstraint _rightIKConstraint;
	private MultiRotationConstraint _leftMultiRotationConstraint;
	private MultiRotationConstraint _rightMultiRotationConstraint;
	private Rigidbody _rigidbody;
	private CapsuleCollider _rootCollider;
	private Transform _rootTransform;

	public EnvironmentInteractionContext(TwoBoneIKConstraint leftIKConstraint,
	TwoBoneIKConstraint rightIKConstraint, MultiRotationConstraint leftMultiRotationConstraint,
	MultiRotationConstraint rightMultiRotationConstraint,
	Rigidbody rigidbody, CapsuleCollider rootCollider, Transform rootTransform)
	{
		_leftIKConstraint = leftIKConstraint;
		_rightIKConstraint = rightIKConstraint;
		_leftMultiRotationConstraint = leftMultiRotationConstraint;
		_rightMultiRotationConstraint = rightMultiRotationConstraint;
		_rigidbody = rigidbody;
		_rootCollider = rootCollider;
		_rootTransform = rootTransform;

		CharacterShoulderHeight = leftIKConstraint.data.root.transform.position.y;
	}

	// When states need to access the constraints from the context
	// Read-only properties
	public TwoBoneIKConstraint LeftIKConstraint => _leftIKConstraint;
	public TwoBoneIKConstraint RightIKConstraint => _rightIKConstraint;
	public MultiRotationConstraint LeftMultiRotationConstraint => _leftMultiRotationConstraint;
	public MultiRotationConstraint RightMultiRotationConstraint => _rightMultiRotationConstraint;
	public Rigidbody Rigidbody => _rigidbody;
	public CapsuleCollider RootCollider => _rootCollider;
	public Transform RootTransform => _rootTransform;

	public float CharacterShoulderHeight { get; private set; }

	public Collider CurrentIntersectingCollider { get; set; }
	public TwoBoneIKConstraint CurrentIkConstraint { get; private set; }
	public MultiRotationConstraint CurrentMultiRotationConstraint { get; private set; }
	public Transform CurrentIkTargetTransform { get; private set; }
	public Transform CurrentShoulderTransform { get; private set; }
	public EBodySide CurrentBodySide { get; private set; }
	public Vector3 ClosestPointOnColliderFromShoulder { get; set; } = Vector3.positiveInfinity;

	public void SetCurrentSide(Vector3 positionToCheck)
	{
		Vector3 leftShoulder = _leftIKConstraint.data.root.transform.position;
		Vector3 rightShoulder = _rightIKConstraint.data.root.transform.position;

		bool isLeftCloser = Vector3.Distance(positionToCheck, leftShoulder) < Vector3.Distance(positionToCheck, rightShoulder);
		if (isLeftCloser)
		{
			Debug.Log("Left side is closer");
			CurrentBodySide = EBodySide.LEFT;
			CurrentIkConstraint = _leftIKConstraint;
			CurrentMultiRotationConstraint = _leftMultiRotationConstraint;
		}
		else
		{
			Debug.Log("Right side is closer");
			CurrentBodySide = EBodySide.RIGHT;
			CurrentIkConstraint = _rightIKConstraint;
			CurrentMultiRotationConstraint = _rightMultiRotationConstraint;
		}

		CurrentShoulderTransform = CurrentIkConstraint.data.root.transform;
		CurrentIkTargetTransform = CurrentIkConstraint.data.target.transform;
	}
}
