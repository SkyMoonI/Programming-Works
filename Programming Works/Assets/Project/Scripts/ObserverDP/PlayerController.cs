using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Subject
{
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			Die();
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			Attack();
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			CollectItem();
		}
	}

	void Jump()
	{
		// jump mechanism
		NotifyObservers(PlayerActions.Jump);
	}

	void Die()
	{
		// die mechanism
		NotifyObservers(PlayerActions.Die);
	}

	void Attack()
	{
		// attack mechanism
		NotifyObservers(PlayerActions.Attack);
	}

	void CollectItem()
	{
		// collect item mechanism
		NotifyObservers(PlayerActions.CollectItem);
	}
}
