using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	public GameObject PrefabPlatform;
	public float startPlatforms;
	public float horizontalDistance;
	public float verticalDistance;

	private float platformPositionY;
	

	private void Start()
	{
		for (int i = 0; i < startPlatforms; i++)
		{
			platformPositionY = i*verticalDistance;
			CreatePlatform();
		}
		
	}

	private void Update()
	{
		
	}

	private void CreatePlatform()
	{
		int newPlatformType = Random.Range(-1, 3);
		float platformPositionX;

		if (newPlatformType < 2)
		{
			platformPositionX = newPlatformType * horizontalDistance;
		}
		else
		{
			platformPositionX = 1 * horizontalDistance;
			Instantiate(PrefabPlatform, new Vector3(-platformPositionX, platformPositionY, 0), Quaternion.identity, transform);
		}

		Instantiate(PrefabPlatform, new Vector3(platformPositionX, platformPositionY, 0), Quaternion.identity, transform);
	}

}
