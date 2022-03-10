using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
	private void FixedUpdate()
	{
		transform.position += transform.forward * Time.deltaTime;
	}
}
