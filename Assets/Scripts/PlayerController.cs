using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Mover mover;
	[SerializeField]
	private Shooter shooter;
	[SerializeField]
	private AudioPlayer audioPlayer;

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

		mover.Move(inputDir);
		audioPlayer.PlayMove(inputDir);
		animator.SetFloat("Accel", inputDir.sqrMagnitude);
	}

	private void OnFire(InputValue value)
	{
		shooter.Shoot();
		audioPlayer.PlayShoot();
		animator.SetTrigger("Shoot");
	}

	private void OnFocus(InputValue value)
	{
		shooter.Focus(value.isPressed);
	}
}
