using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float shootingInterval = 0.5f;
    public float bulletSpeed = 10.0f;

    private float nextShootTime = 0.0f;

    private void Update()
    {
        // Check if it's time to shoot
        if (Time.time >= nextShootTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // You can use any other input key you prefer
            {
                Shoot();
                nextShootTime = Time.time + shootingInterval;
            }
        }
    }

    private void Shoot()
    {
        // Create a bullet and set its velocity
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.up * bulletSpeed;
    }
}
