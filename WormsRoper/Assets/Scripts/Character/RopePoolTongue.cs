using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePoolTongue : MonoBehaviour
{
	public static List<GameObject> RopeJoints = new List<GameObject>();
	public static List<GameObject> RopeJointsPool = new List<GameObject>();
	private LineRenderer line;

	private void Start()
	{
		line = GetComponent<LineRenderer>();
		for (int i = 0; i < transform.childCount-1 ; i++)
		{
			RopeJointsPool.Add(transform.GetChild(i).gameObject);
		}
		
	}

	private void Update()
    {
		if (RopeJoints.Count > 0)
		{
			line.positionCount = RopeJoints.Count;
			for (int i = 0; i < RopeJoints.Count; i++)
			{
				line.SetPosition(i, RopeJoints[i].transform.position);
			}
		}
		else
		{
			line.positionCount = 0;
		}
    }

	public static void ClearJoints()
	{
		
		if (RopeJoints.Count <= 0) return;
		for (int i = 0; i < RopeJoints.Count; i++)
		{
			RopeJoints[i].gameObject.SendMessage("DestroyNow");

		}
		RopeJoints.Clear();
	}
}
