using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMovementManager : MonoBehaviour
{
	private JumpManager jumpManager;
	private ShootManager shootManager;

	public string activeMovementIndex;


	private void Start()
	{
		/*
		jumpManager = GetComponent<JumpManager>();
		shootManager = GetComponent<ShootManager>();
		ChangeMode();
		ChangeMode();
		*/
		transform.forward = Vector3.up;
	}


	private void Update()
	{
		/*
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ChangeMode();
		}
		*/
	}


	public void ChangeMode()
	{
		jumpManager.enabled = false;
		shootManager.enabled = false;
		switch (activeMovementIndex)
		{
			default:
			case "shoot":
			case "Shoot":
			
				jumpManager.enabled = true;
				activeMovementIndex = "Jump";
				break;
			case "jump":
			case "Jump":
				shootManager.enabled = true;
				activeMovementIndex = "Shoot";
				break;
		}
	}

}
