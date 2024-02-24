using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] float movePower;
    [SerializeField] float maxSpeed;
    [SerializeField] float rotateSpeed;

    private Vector3 moveDir;

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetDir(Vector3 dir)
    {
        moveDir = dir;
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
}
