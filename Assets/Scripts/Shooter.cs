using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform muzzlePoint;

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        bullet.speed = bulletSpeed;
    }
}
