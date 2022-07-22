using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPointManager : MonoBehaviour
{
	
	public static Vector3 pointToShoot;
	public static Vector3 pointToUnshoot;
	public static bool isTouching;
	public static float timePressed;
	public static float timeAtTouch;

	private void FixedUpdate()
	{
		if (!isTouching) return;
		timePressed = Time.time - timeAtTouch;
	}


	private void OnMouseDown()
	{
		pointToShoot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		isTouching = true;
		timeAtTouch = Time.time;
	}


	private void OnMouseDrag()
	{
		pointToUnshoot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		isTouching = true;
	}

	private void OnMouseUp()
	{
		if(Input.touchCount == 0)
		isTouching = false;
		timePressed = Time.time - timeAtTouch;
	}
}
