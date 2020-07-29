using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float health;
    private GameObject enemy;

    private float damage;

    public ParticleSystem particle;

  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy") == true)
        {
            damage = collision.collider.GetComponent<EnemyCombat>().meleeDamage;
            GetDamage(damage);
        }

        if (health <= 0)
        {
            Death();
        }
    }

    private void GetDamage(float damage)
    {
        particle.Play();
        health -= damage;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
