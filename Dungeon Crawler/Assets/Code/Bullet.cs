using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float damage = 1f;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject != player)
        {
            Destroy(gameObject);
        }
      
    }
}
