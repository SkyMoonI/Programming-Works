using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	Animator _playerAnimator;
	// Start is called before the first frame update
	void Awake()
	{
		_playerAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
		{
			_playerAnimator.SetBool("IsRunning", true);
			_playerAnimator.SetBool("IsWalking", false);
			transform.Translate(Vector3.forward * 6 * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.W))
		{
			_playerAnimator.SetBool("IsWalking", true);
			_playerAnimator.SetBool("IsRunning", false);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}
		else
		{
			_playerAnimator.SetBool("IsWalking", false);
			_playerAnimator.SetBool("IsRunning", false);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, -90 * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, 90 * Time.deltaTime, 0);
		}
	}
}
