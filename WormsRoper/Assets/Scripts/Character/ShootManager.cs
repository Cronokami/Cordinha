using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
	public GameObject projectile;
	public ObjectBoolean activate;
	private bool shot;
	private HingeJoint2D hinge;
	public GameObject ropePoolGameObject;
	private Rigidbody2D rb2d;
	GameObject firstJoint;

	
	
    void Start()
    {
		hinge = GetComponent<HingeJoint2D>();
		rb2d = GetComponent<Rigidbody2D>();
    }
	
    void Update()
    {
		if (TouchPointManager.isTouching)
		{
			if (!shot)
			{
				shot = true;
				transform.rotation = Quaternion.LookRotation(new Vector3(TouchPointManager.pointToShoot.x, TouchPointManager.pointToShoot.y, transform.position.z) - transform.position);
				
				firstJoint = Instantiate(projectile, transform.localPosition, transform.localRotation, ropePoolGameObject.transform);
				RopePoolTongue.RopeJoints.Add(firstJoint);
				//hinge.connectedBody = corda.GetComponent<Rigidbody2D>();
				HingeJoint2D newJoint;
				newJoint = firstJoint.GetComponent<HingeJoint2D>();
				newJoint.connectedBody = rb2d;
				activate.value = true;
			}
			else
			{
				transform.rotation = firstJoint.transform.rotation;
			}
			
		}

		if (!TouchPointManager.isTouching)
		{
			if (shot)
			{
				
				RopePoolTongue.ClearJoints();

			}

			shot = false;
			activate.value = false;
			
		}

		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.yellow);
	}
	

	private void OnDisable()
	{
		RopePoolTongue.ClearJoints();
		
	}
}
