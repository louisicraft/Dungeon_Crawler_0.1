using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float health;
    public float meleeDamage = 1f;
    private ParticleSystem particle;


    void Start()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            GetDamage(collision.collider.GetComponent<Bullet>().damage); 
        }
    }
    public void GetDamage(float damage)
    {
        particle.Play();
        health -= damage;
        if(health <= 0)
        {
            particle.Play();
            Destroy(gameObject,0.1f);
        }
    }
}
