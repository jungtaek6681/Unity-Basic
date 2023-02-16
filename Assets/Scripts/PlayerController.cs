using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Spec")]
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float rotateSpeed;

	[Header("Shooter")]
	[SerializeField]
	private Transform shootTransform;
	[SerializeField]
	private Bullet bulletPrefab;

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

	private void OnFire(InputValue value)
	{
		Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);
	}
}
