using UnityEngine;

public class Jumper : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float jumpPower;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}