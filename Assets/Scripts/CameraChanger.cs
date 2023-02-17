using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChanger : MonoBehaviour
{
	[SerializeField]
	private CinemachineVirtualCamera virCamera;

	[SerializeField]
	private CinemachineFreeLook freeCamera;

	private void OnSetPriority1(InputValue value)
	{
		Debug.Log("Camera1 Focused");
		virCamera.Priority = 20;
		freeCamera.Priority = 0;
	}

	private void OnSetPriority2(InputValue value)
	{
		Debug.Log("Camera2 Focused");
		virCamera.Priority = 0;
		freeCamera.Priority = 20;
	}
}
