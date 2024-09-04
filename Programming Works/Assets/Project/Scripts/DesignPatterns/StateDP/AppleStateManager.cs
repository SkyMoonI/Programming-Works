using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStateManager : MonoBehaviour
{
	AppleBaseState _appleCurrentState;
	public AppleGrowingState _appleGrowingState = new AppleGrowingState();
	public AppleWholeState _appleWholeState = new AppleWholeState();
	public AppleChewedState _appleChewedState = new AppleChewedState();
	public AppleRottenState _appleRottenState = new AppleRottenState();


	// Start is called before the first frame update
	void Start()
	{
		// starting state for the state machine
		_appleCurrentState = _appleGrowingState;
		// "this" is a reference to the current object
		_appleCurrentState.EnterState(this);
	}

	// Update is called once per frame
	void Update()
	{
		_appleCurrentState.UpdateState(this);
	}

	public void SwitchState(AppleBaseState state)
	{
		_appleCurrentState = state;
		_appleCurrentState.EnterState(this);
	}
	void OnCollisionEnter(Collision other)
	{
		_appleCurrentState.OnCollisionEnter(this, other);
	}
}
