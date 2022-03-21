using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
	private bool shot;
	private Vector3 baseShotPoint;
	private Vector3 endShotPoint;
	private Rigidbody2D rb2D;
	public float jumpForce;

	public bool debugShowLineLonger;

	private LineRenderer lineRenderer;


	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (rb2D.constraints == RigidbodyConstraints2D.None) return;
		if (TouchPointManager.isTouching)
		{	
			if (!shot)
			{
				baseShotPoint = TouchPointManager.pointToShoot;
				shot = true;
			}
			endShotPoint = TouchPointManager.pointToUnshoot;
			PlotTrajectory(transform.position, (endShotPoint - baseShotPoint) * 0.86f , 0.02f, 5f);
		}
		if (!TouchPointManager.isTouching && shot)
		{
			if(!debugShowLineLonger) lineRenderer.positionCount = 0;
			shot = false;
			rb2D.constraints = RigidbodyConstraints2D.None;
			rb2D.AddForce((endShotPoint - baseShotPoint) * jumpForce);
		}
	}

	public void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime)
	{

		int index = 0;

		Vector3 prev = start;
		for (int i = 1; ; i++)
		{
			float t = timestep * i;
			if (t > maxTime) break;
			Vector3 pos = PlotTrajectoryAtTime(start, startVelocity, t);
			lineRenderer.positionCount = ((int)(maxTime / timestep));

			if (Physics.Linecast(prev, pos))
			{
				lineRenderer.positionCount = index;
				break;
			}
			else
			{
				lineRenderer.SetPosition(index, pos);
				Debug.DrawLine(prev, pos, Color.red);
				prev = pos;
				index++;
			}
		}
	}

	public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
	{
		return start + startVelocity * time + Physics.gravity * time * time * 0.5f;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Wall") && this.isActiveAndEnabled)
		{
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

	private void OnDisable()
	{
		rb2D.constraints = RigidbodyConstraints2D.None;
	}
}
