using UnityEngine;
public class AppleChewedState : AppleBaseState
{
	float _destroyCountdown = 5f;
	public override void EnterState(AppleStateManager apple)
	{
		Debug.Log("Apple is chewed");
	}

	public override void UpdateState(AppleStateManager apple)
	{
		if (_destroyCountdown >= 0)
		{
			_destroyCountdown -= Time.deltaTime;
		}
		else
		{
			Object.Destroy(apple.gameObject);
		}
	}

	public override void OnCollisionEnter(AppleStateManager apple, Collision other)
	{
	}


}
