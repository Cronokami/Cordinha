using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPointManager : MonoBehaviour
{
	
	public static Vector3 pointToShoot;
	public static Vector3 pointToUnshoot;
	public static bool isTouching;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


	private void OnMouseDown()
	{
		pointToShoot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		isTouching = true;
	}


	private void OnMouseDrag()
	{
		pointToUnshoot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		isTouching = true;
	}

	private void OnMouseUp()
	{
		isTouching = false;
	}
}
