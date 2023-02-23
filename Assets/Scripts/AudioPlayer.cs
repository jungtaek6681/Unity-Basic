using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	[SerializeField]
	private AudioSource idleSource;
	[SerializeField]
	private AudioSource driveSource;
	[SerializeField]
	private AudioSource shootSource;

	private bool isMoving = false;

	private void Start()
	{
		idleSource.Play();
		driveSource.Stop();
		shootSource.Stop();
	}

	public void PlayMove(Vector3 moveDir)
	{
		if (isMoving)
		{
			if (moveDir.sqrMagnitude < 0.1f * 0.1f)
			{
				isMoving = false;
				idleSource.Play();
				driveSource.Stop();
			}
		}
		else
		{
			if (moveDir.sqrMagnitude > 0.1f * 0.1f)
			{
				isMoving = true;
				idleSource.Stop();
				driveSource.Play();
			}
		}
	}

	public void PlayShoot()
	{
		shootSource.Play();
	}
}
