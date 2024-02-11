using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] GameObject explosionEffect;
    public float speed;

    private void Start()
    {
        rigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
