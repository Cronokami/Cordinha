﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueTip : MonoBehaviour
{
	public Transform firstParent;
	private Transform followTransform;

	private RopePoolTongue poolTongue;
	public ObjectBoolean elongate;
	private SpriteRenderer sprite;

	public Sprite hand;
	public Sprite fist;

	
	private void Start()
    {
		poolTongue = GetComponentInParent<RopePoolTongue>();
		sprite = GetComponent<SpriteRenderer>();
		followTransform = firstParent;
    }
	

    private void Update()
    {
		if (elongate.value)
		{
			sprite.sprite = hand;
		}
		else
		{
			sprite.sprite = fist;
		}
		transform.up = followTransform.forward;
		transform.position = followTransform.position;
	}


	private void IAmTip(Transform tip)
	{
		followTransform = tip;
	}

	private void IAmNotTip()
	{
		followTransform = firstParent;
	}
}
