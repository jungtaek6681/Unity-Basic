using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float bulletSpeed;

    [SerializeField] float movePower;
    [SerializeField] float maxSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] CinemachineVirtualCamera focusCamera;

    [SerializeField] AudioSource idleSource;
    [SerializeField] AudioSource driveSource;
    [SerializeField] AudioSource fireSource;

    [SerializeField] Animator animator;

    private Vector3 moveDir;

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (rigidbody.velocity.sqrMagnitude < maxSpeed * maxSpeed)
        {
            rigidbody.AddForce(transform.forward * moveDir.z * movePower);
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.World);
    }

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        bullet.speed = bulletSpeed;
        fireSource.Play();
        animator.SetTrigger("Fire");
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;

        if (input.sqrMagnitude > 0)
        {
            idleSource.Stop();
            driveSource.Play();
        }
        else
        {
            idleSource.Play();
            driveSource.Stop();
        }
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Fire();
        }
    }

    private void OnFocus(InputValue value)
    {
        focusCamera.Priority = value.isPressed ? 20 : 5;
    }
}
