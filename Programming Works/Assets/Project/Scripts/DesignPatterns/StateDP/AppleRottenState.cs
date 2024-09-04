using UnityEngine;
public class AppleRottenState : AppleBaseState
{
	public override void EnterState(AppleStateManager apple)
	{
		Debug.Log("Apple is rotten");
	}

	public override void UpdateState(AppleStateManager apple)
	{
	}

	public override void OnCollisionEnter(AppleStateManager apple, Collision other)
	{
		GameObject otherObject = other.gameObject;
		if (otherObject.tag == "Player")
		{
			otherObject.GetComponent<PlayerController2>().DetractHealth();
			apple.SwitchState(apple._appleChewedState);
		}
	}


}
