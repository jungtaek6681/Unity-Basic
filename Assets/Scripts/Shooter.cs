using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[Header("Shooter")]
	[SerializeField]
	private CinemachineVirtualCamera focuseCam;
	[SerializeField]
	private Bullet bulletPrefab;

	public void Shoot()
	{
		Instantiate(bulletPrefab, transform.position, transform.rotation);

		// ?̱????? ?̿??? ????????
		GameManager.Data.AddShootCount(1);
	}

	public void Focus(bool focus)
	{
		focuseCam.Priority = focus ? 999 : 0;
	}
}
