using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainJointManager : MonoBehaviour
{
	public Rigidbody2D rb2d;
	public SpringJoint2D sj2d;
	public SpriteRenderer spriteRenderer;

	public ChainJointStats stats;
	public ObjectBoolean elongate;

	public GameObject jointPrefab;
	private bool tip;

	private Rigidbody2D previousJoint;//useless for now but have plans on using it
	public float startUnitDistance;

	
	private void OnEnable()
	{
		rb2d.constraints = RigidbodyConstraints2D.None;
		StartCoroutine(ShouldCreateJoint());
		RopePoolTongue.RopeJoints++;
		tip = true;
		/*
		if (previousJoint != null)
		{
			startUnitDistance = Vector2.Distance(transform.position, previousJoint.transform.position);
		}*/
	}

	private void Start()
	{
		//can't make this on Awake due to needing other codes to do stuff on start for this to work
		/*
		previousJoint = gameObject.GetComponent<SpringJoint2D>().connectedBody;
		startUnitDistance = Vector2.Distance(transform.position, previousJoint.transform.position);
		*/
	}


	private void Update()
	{
		if (tip)
		{
			RopePoolTongue.hand.SendMessage("IAmTip", transform);
		}
	}

	private void FixedUpdate()
	{
		/*
		if (Vector2.Distance(transform.position, previousJoint.transform.position) > startUnitDistance)
		{
			rb2d.AddForce(previousJoint.transform.position - transform.position);

		}
		*/
	}

	private IEnumerator ShouldCreateJoint()
	{
		yield return new WaitForSeconds(stats.shotSpeed);
		if (!elongate.value) StartCoroutine(ShouldCreateJoint());
		else if(RopePoolTongue.RopeJointsPool.Count > RopePoolTongue.RopeJoints)
		{
			GameObject nextJoint = RopePoolTongue.RopeJointsPool[RopePoolTongue.RopeJoints];
			nextJoint.transform.position = transform.position + transform.forward * spriteRenderer.bounds.size.x * stats.distanceMultiplier;
			nextJoint.transform.rotation = transform.rotation;
			nextJoint.SetActive(true);
			yield return new WaitForSeconds(stats.shotSpeed / 2);
			tip = false;
		}
	}

	private void DestroyNow()
	{
		gameObject.SetActive(false);
		startUnitDistance = 0;
		transform.localPosition = Vector3.zero;
		if (tip)
		{
			RopePoolTongue.hand.SendMessage("IAmNotTip");
		}


	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Wall") && tip)
		{
			elongate.value = false;
			rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
			
		}
	}

}
