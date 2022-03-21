using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartledYoshiMovement : MonoBehaviour
{
	private bool isGrounded;
	public ObjectBoolean elongate;
	public float horizontalVelocity;
	private Rigidbody2D rb2d;
	private ShootManager shootManager;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		shootManager = GetComponent<ShootManager>();
	}

	private void Update()
	{
		if (isGrounded && !shootManager.shot)
		{

			rb2d.velocity = new Vector2(horizontalVelocity, rb2d.velocity.y);
			
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Wall") && this.isActiveAndEnabled)
		{
			isGrounded = true;
		}

		if (collision.collider.CompareTag("ReboundWall") && this.isActiveAndEnabled)
		{

			horizontalVelocity = -horizontalVelocity;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Wall") && this.isActiveAndEnabled)
		{
			isGrounded = false;
		}
	}
}
