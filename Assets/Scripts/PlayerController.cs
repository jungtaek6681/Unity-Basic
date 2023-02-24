using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public UnityEvent<Vector3> OnMoved;
	public UnityEvent OnShooted;
	public UnityEvent<bool> OnFocused;

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void OnMove(InputValue value)
	{
		Vector3 inputDir = new Vector3();
		inputDir.x = value.Get<Vector2>().x;
		inputDir.z = value.Get<Vector2>().y;

		OnMoved?.Invoke(inputDir);
		animator.SetFloat("Accel", inputDir.sqrMagnitude);
	}

	private void OnFire(InputValue value)
	{
		OnShooted?.Invoke();
		animator.SetTrigger("Shoot");
	}

	private void OnFocus(InputValue value)
	{
		OnFocused?.Invoke(value.isPressed);
	}
}
