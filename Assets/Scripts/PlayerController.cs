using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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

	[SerializeField]
	private AudioClip idleClip;
	[SerializeField]
	private AudioClip driveClip;

	[Header("Shooter")]
	[SerializeField]
	private CinemachineVirtualCamera focuseCam;
	[SerializeField]
	private Transform shootTransform;
	[SerializeField]
	private Bullet bulletPrefab;
	[SerializeField]
	private AudioSource shootSound;

	private new Rigidbody rigidbody;
	private Vector3 inputDir;
	private AudioSource audioSource;
	private Animator animator;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		UpdateMove();
		UpdateRotate();
		UpdateSound();
		UpdateAnimator();
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

	private void UpdateSound()
	{
		if (inputDir.sqrMagnitude > 0.1f * 0.1f && audioSource.clip != driveClip)
		{
			audioSource.Stop();
			audioSource.clip = driveClip;
			audioSource.Play();
		}
		else if (inputDir.sqrMagnitude <= 0.1f * 0.1f && audioSource.clip != idleClip)
		{
			audioSource.Stop();
			audioSource.clip = idleClip;
			audioSource.Play();
		}
	}

	private void UpdateAnimator()
	{
		animator.SetFloat("Accel", inputDir.sqrMagnitude);
	}

	private void OnMove(InputValue value)
	{
		inputDir.x = value.Get<Vector2>().x;
		inputDir.z = value.Get<Vector2>().y;
		Debug.Log(inputDir);
	}

	private void OnFire(InputValue value)
	{
		Shoot();
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

	public void Shoot()
	{
		Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);
		shootSound.Play();
		animator.SetTrigger("Shoot");
	}
}
