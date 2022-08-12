using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraResolution : MonoBehaviour
{
	private CinemachineVirtualCamera cam;
	public Vector2 resolutionBase;

	float resolutionVariable;

	private void Start()
	{
		cam = GetComponent<CinemachineVirtualCamera>();
		resolutionVariable = 10 / (resolutionBase.y / resolutionBase.x);
		cam.m_Lens.OrthographicSize = resolutionVariable* ((float)Screen.currentResolution.width / (float)Screen.currentResolution.height);
	}

}
