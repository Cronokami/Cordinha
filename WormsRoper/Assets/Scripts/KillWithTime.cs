using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWithTime : MonoBehaviour
{
	public float secondsToKill;
	private SpriteRenderer spriteRenderer;
	void Start()
	{
		Destroy(gameObject, secondsToKill);
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - Time.deltaTime/secondsToKill);
	}
}
