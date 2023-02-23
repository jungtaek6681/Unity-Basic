using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mover : MonoBehaviour
{
	[Header("Mover")]
	[SerializeField]
	private float movePower;
	[SerializeField]
	private float maxMove;
	[SerializeField]
	private float rotatePower;
	[SerializeField]
	private float maxRotate;

	[SerializeField]
	private new Rigidbody rigidbody;

	private Vector3 moveDir;

	private void Update()
	{
		UpdateMove();
		UpdateRotate();
	}

	private void UpdateMove()
	{
		rigidbody.AddForce(transform.forward * moveDir.z * movePower);

		if (rigidbody.velocity.magnitude > maxMove)
			rigidbody.velocity = rigidbody.velocity.normalized * maxMove;
	}

	private void UpdateRotate()
	{
		rigidbody.AddTorque(Vector3.up * moveDir.x * rotatePower);

		if (rigidbody.angularVelocity.magnitude > maxRotate)
			rigidbody.angularVelocity = rigidbody.angularVelocity.normalized * maxRotate;
	}

	public void Move(Vector3 moveDir)
	{
		this.moveDir = moveDir;
	}
}
