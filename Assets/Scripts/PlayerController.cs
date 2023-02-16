using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float rotateSpeed;

	private Vector3 inputDir;

	private void Update()
	{
		UpdateMove();
		UpdateRotate();
	}

	private void UpdateMove()
	{
		transform.Translate(Vector3.forward * inputDir.z * moveSpeed * Time.deltaTime, Space.Self);
	}

	private void UpdateRotate()
	{
		transform.Rotate(Vector3.up, inputDir.x * rotateSpeed * Time.deltaTime, Space.World);
	}

	private void OnMove(InputValue value)
	{
		inputDir.x = value.Get<Vector2>().x;
		inputDir.z = value.Get<Vector2>().y;
		Debug.Log(inputDir);
	}
}
