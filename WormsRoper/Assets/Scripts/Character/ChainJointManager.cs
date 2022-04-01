using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainJointManager : MonoBehaviour
{
	public Rigidbody2D rb2d;
	public HingeJoint2D hj2d;
	public SpriteRenderer spriteRenderer;

	public ChainJointStats stats;
	public ObjectBoolean elongate;
	private bool turnOff;

	public GameObject jointPrefab;
	private bool tip;

	private Transform previousJoint;//useless for now but have plans on using it
	private float startUnitDistance;

	private void OnEnable()
	{
		rb2d.constraints = RigidbodyConstraints2D.None;
		StartCoroutine(ShouldCreateJoint());
		RopePoolTongue.RopeJoints++;
		tip = true;
		startUnitDistance = Vector2.Distance(transform.position, gameObject.GetComponent<HingeJoint2D>().connectedBody.transform.position);  //this is the stuff I'm working on
	}

	private void Update()
	{

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
		transform.localPosition = Vector3.zero;
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Wall") && tip)
		{
			elongate.value = false;
			rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
			Debug.Log("bateu");

		}
	}

}
