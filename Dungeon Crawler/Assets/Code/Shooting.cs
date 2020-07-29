using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float cooldown = 0.2f;
    private float cooldownTimer = 0f;


    void Update()
    {
        if (cooldownTimer <= Time.time && Input.GetButton("Fire1"))
        {
            Shoot();
            cooldownTimer = Time.time + cooldown;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
