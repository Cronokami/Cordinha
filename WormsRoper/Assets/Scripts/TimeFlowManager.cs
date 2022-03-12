using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowManager : MonoBehaviour
{
	public static GameObject singleton;
	private float originalTimeScale;
	public float manualScale;
	private float fixedDeltaTime;

	private void Awake()
	{
		if (singleton == null)
		{
			singleton = gameObject;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		

		fixedDeltaTime = Time.fixedDeltaTime;
		originalTimeScale = Time.timeScale;
		Time.timeScale = originalTimeScale * manualScale;
		Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
		DontDestroyOnLoad(gameObject);
	}

}
