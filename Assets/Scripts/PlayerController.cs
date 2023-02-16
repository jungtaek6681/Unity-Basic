using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;

	private Vector3 moveDir;

	private void Update()
	{
		UpdateMove();
	}

	private void UpdateMove()
	{
		transform.position += moveDir * moveSpeed * Time.deltaTime;
	}

	private void OnMove(InputValue value)
	{
		moveDir.x = value.Get<Vector2>().x;
		moveDir.z = value.Get<Vector2>().y;
		Debug.Log(moveDir);
	}
}
