using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public bool roomIsClear = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == true)
        {
            for (int i = 0; i < 2 && roomIsClear; ++i)
            {

            }
                roomIsClear = false;
        }
        
    }              
}

