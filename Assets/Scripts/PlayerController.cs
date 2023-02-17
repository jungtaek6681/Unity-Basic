using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Spec")]
	[SerializeField]
	private float movePower;
	[SerializeField]
	private float maxMove;
	[SerializeField]
	private float rotatePower;
	[SerializeField]
	private float maxRotate;

	[Header("Shooter")]
	[SerializeField]
	private CinemachineVirtualCamera focuseCam;
	[SerializeField]
	private Transform shootTransform;
	[SerializeField]
	private Bullet bulletPrefab;

	private new Rigidbody rigidbody;
	private Vector3 inputDir;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		UpdateMove();
		UpdateRotate();
	}

	private void UpdateMove()
	{
		rigidbody.AddForce(transform.forward * inputDir.z * movePower);

		if (rigidbody.velocity.magnitude > maxMove)
			rigidbody.velocity = rigidbody.velocity.normalized * maxMove;
	}

	private void UpdateRotate()
	{
		rigidbody.AddTorque(Vector3.up * inputDir.x * rotatePower);

		if (rigidbody.angularVelocity.magnitude > maxRotate)
			rigidbody.angularVelocity = rigidbody.angularVelocity.normalized * maxRotate;
	}

	private void OnMove(InputValue value)
	{
		inputDir.x = value.Get<Vector2>().x;
		inputDir.z = value.Get<Vector2>().y;
		Debug.Log(inputDir);
	}

	private void OnFire(InputValue value)
	{
		Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);
	}

	private void OnFocus(InputValue value)
	{
		if (value.isPressed)
		{
			Debug.Log("OnFocused");
			focuseCam.Priority = 999;
		}
		else
		{
			Debug.Log("OnUnFocused");
			focuseCam.Priority = 0;
		}
	}
}
