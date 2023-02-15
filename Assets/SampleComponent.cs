using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleComponent : MonoBehaviour
{
	public new Rigidbody rigidbody;

	public float movePower;
	public float jumpPower;

	private void Update()
	{
		Move();
		Jump();
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
			rigidbody.AddForce(Vector3.left * movePower, ForceMode.Force);

		if (Input.GetKey(KeyCode.RightArrow))
			rigidbody.AddForce(Vector3.right * movePower, ForceMode.Force);

		if (Input.GetKey(KeyCode.UpArrow))
			rigidbody.AddForce(Vector3.forward * movePower, ForceMode.Force);

		if (Input.GetKey(KeyCode.DownArrow))
			rigidbody.AddForce(Vector3.back * movePower, ForceMode.Force);
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	}
}
