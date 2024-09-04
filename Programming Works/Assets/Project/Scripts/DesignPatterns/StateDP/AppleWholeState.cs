using UnityEngine;
public class AppleWholeState : AppleBaseState
{
	float _rottenCountdown = 5f;
	public override void EnterState(AppleStateManager apple)
	{
		Debug.Log("Apple is whole");
		apple.GetComponent<Rigidbody>().useGravity = true;
	}

	public override void UpdateState(AppleStateManager apple)
	{
		if (_rottenCountdown >= 0)
		{
			_rottenCountdown -= Time.deltaTime;
		}
		else
		{
			apple.SwitchState(apple._appleRottenState);
		}
	}

	public override void OnCollisionEnter(AppleStateManager apple, Collision other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.tag == "Player")
		{
			otherObject.GetComponent<PlayerController2>().AddHealth();
			apple.SwitchState(apple._appleChewedState);
		}
	}


}
