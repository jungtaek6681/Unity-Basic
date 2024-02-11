using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] new Rigidbody rigidbody;
    public float speed;

    private void Start()
    {
        rigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }
}
