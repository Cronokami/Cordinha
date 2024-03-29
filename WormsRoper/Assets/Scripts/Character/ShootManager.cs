﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
	public GameObject projectile;
	public ObjectBoolean activate;
	public bool shot;
	private HingeJoint2D hinge;
	public GameObject ropePoolGameObject;
	private Rigidbody2D rb2d;
	GameObject firstJoint;

	private bool constantTouch = false;
	
	
    void Start()
    {
		hinge = GetComponent<HingeJoint2D>();
		rb2d = GetComponent<Rigidbody2D>();
		firstJoint = RopePoolTongue.RopeJointsPool[0];
		shot = false;
	}
	
    void Update()
    {
		if (TouchPointManager.isTouching && !CharacterTouchDrag.isDragging)
		{
			if (!constantTouch)
			{
				if (!shot)
				{

					shot = true;
					transform.rotation = Quaternion.LookRotation(new Vector3(TouchPointManager.pointToShoot.x, TouchPointManager.pointToShoot.y, transform.position.z) - transform.position);
					firstJoint.transform.position = transform.localPosition;
					firstJoint.transform.rotation = transform.localRotation;
					firstJoint.SetActive(true);
					activate.value = true;
				}
				else
				{
					shot = false;
					activate.value = false;
					RopePoolTongue.ClearJoints();
				}
				constantTouch = true;
			}
			
		}

		if (!TouchPointManager.isTouching)
		{
			constantTouch = false;			
		}

		if (firstJoint.activeSelf)
		{
			transform.rotation = firstJoint.transform.rotation;
		}
		
	}
	

	private void OnDisable()
	{
		RopePoolTongue.ClearJoints();
		activate.value = false;
	}
}
