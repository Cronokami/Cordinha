using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePoolTongue : MonoBehaviour
{
	public static int RopeJoints;
	public static List<GameObject> RopeJointsPool = new List<GameObject>();
	private LineRenderer line;

	private void Start()
	{
		line = GetComponent<LineRenderer>();
		for (int i = 0; i < transform.childCount-1 ; i++)
		{
			RopeJointsPool.Add(transform.GetChild(i).gameObject);
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
