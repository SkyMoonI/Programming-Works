using UnityEngine;

public class AppleGrowingState : AppleBaseState
{
	Vector3 _startingAppleSize = new Vector3(.5f, .5f, .5f);
	Vector3 _growAppleScale = new Vector3(.1f, .1f, .1f);
	public override void EnterState(AppleStateManager apple)
	{
		Debug.Log("Apple is growing");
		// set apple starting size when first instantiated
		apple.transform.localScale = _startingAppleSize;
	}

	public override void UpdateState(AppleStateManager apple)
	{
		// if the scale of the apple is less than 1, increase size
		if (apple.transform.localScale.x < 1)
		{
			apple.transform.localScale += _growAppleScale * Time.deltaTime;
			Debug.Log("Apple is growing");
		}
		else
		{
			apple.SwitchState(apple._appleWholeState);
		}
	}
	public override void OnCollisionEnter(AppleStateManager apple, Collision other)
	{

	}

}
