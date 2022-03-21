using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePoolTongue : MonoBehaviour
{
	public static int RopeJoints;
	public static List<GameObject> RopeJointsPool = new List<GameObject>();
	private LineRenderer line;
	public GameObject chainJointPrefab;
	public int poolSize;
	public Rigidbody2D characterRB;

	private void Awake()
	{
		line = GetComponent<LineRenderer>();
		GameObject theJoint;
		HingeJoint2D hinge;
		Rigidbody2D jointRB = null;
		for (int i = 0; i < poolSize; i++)
		{
			theJoint = Instantiate(chainJointPrefab, Vector3.zero, Quaternion.identity, transform);
			hinge = theJoint.GetComponent<HingeJoint2D>();
			if (i == 0)
			{
				hinge.connectedBody = characterRB;
			}
			else
			{
				hinge.connectedBody = jointRB;
			}
			jointRB = theJoint.GetComponent<Rigidbody2D>();
			theJoint.SetActive(false);
			RopeJointsPool.Add(theJoint);
		}

		/*
		for (int i = 0; i < transform.childCount ; i++)
		{
			RopeJointsPool.Add(transform.GetChild(i).gameObject);
		}
		*/
		RopeJoints = 0;
	}

	private void Update()
    {
		if (RopeJoints > 0)
		{
			line.positionCount = RopeJoints;
			for (int i = 0; i < RopeJoints; i++)
			{
				line.SetPosition(i, RopeJointsPool[i].transform.position);
			}
		}
		else
		{
			line.positionCount = 0;
		}
		Debug.Log(RopeJoints);
    }

	public static void ClearJoints()
	{
		
		if (RopeJoints <= 0) return;
		for (int i = 0; i < RopeJoints; i++)
		{
			RopeJointsPool[i].gameObject.SendMessage("DestroyNow");

		}
		RopeJoints = 0;
	}

	private void OnDestroy()
	{
		RopeJointsPool.Clear();
		RopeJoints = 0;
	}
}
