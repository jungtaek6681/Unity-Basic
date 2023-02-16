using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;

	private new Rigidbody rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		Destroy(gameObject, 5);
		rigidbody.velocity = transform.forward * moveSpeed;
	}
}
