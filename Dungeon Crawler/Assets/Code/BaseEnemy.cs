using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{


    

    public Rigidbody2D rb;
 



    //Follow player
    public float followSpeed = 1f;
    private GameObject player;
    private bool aggro = false;


    //Knockback
    private Vector2 knockbackDir;
    public float knockbackForce = 10f;
    
    public float knockTimerPeriod = 2f;
    private float knockTimer = 0f;
    private float flyTimer = 0f;
    public float flyTimerPeriod = 0.1f;

    private bool isKnockDone = true;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

   
    void FixedUpdate()
    {
        FollowPlayer();
        KnockTime();
    }

    private void KnockTime()
    {
        if (flyTimer <= Time.time && isKnockDone == false)
        {
            Debug.Log("frozen");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;        
            isKnockDone = true;
        }
    }

    void OnBecameVisible()
    {
        aggro = true;
    }


    private void FollowPlayer()
    {
        if (knockTimer <= Time.time && aggro == true)
        {
            aggro = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerCollision(collision);

    }

    private void PlayerCollision(Collision2D collision)
    {
        if (collision.collider.gameObject == player)
        {
            //Timers
            knockTimer = Time.time + knockTimerPeriod;
            flyTimer = Time.time + flyTimerPeriod;
            isKnockDone = false;

            rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
            //Berechne Vector2
            knockbackDir = transform.position - player.transform.position;
            //Füge Knockback zu
            rb.velocity = new Vector2(knockbackDir.x * knockbackForce, knockbackDir.y* knockbackForce);
        }
    }
}

