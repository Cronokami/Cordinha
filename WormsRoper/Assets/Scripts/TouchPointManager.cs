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
	public FloatVariable tapThreshold;
	public static FloatVariable swipeTimeLimit;
	public FloatVariable swipeThreshold;

	private void Awake()
	{
		tapTimeLimit = tapThreshold;
		swipeTimeLimit = swipeThreshold;
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
		return false;  //só comecei aqui
	}
}
