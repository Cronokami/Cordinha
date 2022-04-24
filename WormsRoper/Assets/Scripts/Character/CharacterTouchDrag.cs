using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTouchDrag : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public static bool isDragging;
	public float strength = 1;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		isDragging = false;
	}

	private void OnMouseDown()
	{
		isDragging = true;
	}
	private void OnMouseDrag()
	{
		rb2d.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * strength);
	}
	private void OnMouseUp()
	{
		isDragging = false;
	}
}
