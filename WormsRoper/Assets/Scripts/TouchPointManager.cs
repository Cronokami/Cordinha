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
	private static bool tapped;

	public static FloatVariable tapTimeLimit;
	public FloatVariable tapTimeThreshold;
	public static FloatVariable swipeDistanceLimit;
	public FloatVariable swipeDistanceThreshold;
	public static FloatVariable swipeTimeLimit;
	public FloatVariable swipeTimeThreshold;

	private void Awake()
	{
		tapTimeLimit = tapTimeThreshold;
		swipeDistanceLimit = swipeDistanceThreshold;
		swipeTimeLimit = swipeTimeThreshold;
		tapped = false;
		timePressed = 9999;
	}

	private void FixedUpdate()
	{
		if (!isTouching) return;
		
	}


	private void OnMouseDown()
	{
		pointToShoot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		isTouching = true;
		tapped = false;
		timeAtTouch = Time.time;
		timePressed = 9999;
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

	public static bool DidItTap()
	{
		if (tapped) return false;
		if (timePressed >= tapTimeLimit.value) return false;
		tapped = true;
		return true;
	}

	public static bool DidItSwipe()
	{
		if (tapped) return false;
		if (Vector2.Distance(pointToShoot, pointToUnshoot) <= swipeDistanceLimit.value) return false;
		if (timePressed >= swipeTimeLimit.value) return false;
		tapped = true;
		return true;
	}
}
