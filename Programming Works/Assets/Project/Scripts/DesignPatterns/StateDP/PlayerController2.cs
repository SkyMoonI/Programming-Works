using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
		transform.Translate(direction * 2f * Time.deltaTime);
	}

	public void AddHealth()
	{
		Debug.Log("Player healed!");
	}

	public void DetractHealth()
	{
		Debug.Log("Player lost health!");
	}
}
