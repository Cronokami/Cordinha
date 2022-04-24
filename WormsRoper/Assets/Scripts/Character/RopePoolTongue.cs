using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePoolTongue : MonoBehaviour
{
	public static int RopeJoints;
	public static List<GameObject> RopeJointsPool = new List<GameObject>();
	private List<ChainJointManager> chainJointManagers = new List<ChainJointManager>();
	public static float totalDistance;
	private LineRenderer line;
	public GameObject chainJointPrefab;
	public int poolSize;
	public Rigidbody2D characterRB;
	public static Transform hand;

	private void Awake()
	{
		line = GetComponent<LineRenderer>();
		GameObject theJoint;
		HingeJoint2D hinge;
		Rigidbody2D jointRB = null;
		hand = transform.GetChild(0);
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
			chainJointManagers.Add(theJoint.GetComponent<ChainJointManager>());
			jointRB = theJoint.GetComponent<Rigidbody2D>();
			theJoint.SetActive(false);
			RopeJointsPool.Add(theJoint);
		}
		
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
    }

	private void FixedUpdate()
	{
		Vector3 previousPosition = RopeJointsPool[0].transform.position;
		foreach (GameObject joint in RopeJointsPool)
		{
			previousPosition = joint.transform.position;
			totalDistance += Vector3.Distance(joint.transform.position, previousPosition);
		}
		
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
