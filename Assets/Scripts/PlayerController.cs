using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private Vector3 moveDir;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;
    }
}
