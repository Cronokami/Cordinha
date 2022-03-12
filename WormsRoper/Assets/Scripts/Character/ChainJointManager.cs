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

	private void OnEnable()
	{
		//rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
		StartCoroutine(ShouldCreateJoint());
		RopePoolTongue.RopeJoints++;
		tip = true;
	}

	private void Update()
	{
		//rb2d.constraints = elongate.value ? /*RigidbodyConstraints2D.FreezeAll*/ RigidbodyConstraints2D.None : RigidbodyConstraints2D.None;

	}

	private IEnumerator ShouldCreateJoint()
	{
		yield return new WaitForSeconds(stats.shotSpeed);
		if (!elongate.value) StartCoroutine(ShouldCreateJoint());
		else
		{
			GameObject nextJoint = RopePoolTongue.RopeJointsPool[RopePoolTongue.RopeJoints];
			nextJoint.transform.position = transform.position + transform.forward * spriteRenderer.bounds.size.x * stats.distanceMultiplier;
			nextJoint.transform.rotation = transform.rotation;
			nextJoint.SetActive(true);
			yield return new WaitForSeconds(stats.shotSpeed / 2);
			/*
			HingeJoint2D newJoint;
			newJoint = instance.GetComponent<HingeJoint2D>();
			newJoint.connectedBody = rb2d;
			*/
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
