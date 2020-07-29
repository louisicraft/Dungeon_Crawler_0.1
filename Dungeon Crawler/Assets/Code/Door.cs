using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] enemies;

    private BoxCollider2D camCollider;
    private Collider2D camPolygonCollider;
    private CinemachineConfiner camConfiner;

    public bool roomIsClear = false;
    // Start is called before the first frame update
    void Start()
    {
        camConfiner = GameObject.FindGameObjectWithTag("CameraBrain").GetComponent<CinemachineConfiner>();
        camPolygonCollider = this.transform.parent.GetComponent<CompositeCollider2D>();
        camCollider = this.transform.parent.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {          
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            roomIsClear = true;
        }
        else
        {
            roomIsClear = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true && roomIsClear == true)
        {
            if(camCollider.enabled == true)
            {

                camCollider.enabled = false;
              
            }
            else if(camCollider.enabled == false)
            {
                camConfiner.m_BoundingShape2D = camPolygonCollider;
                camCollider.enabled = true;        
            }         
        }
    }
}
