using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //die collider gehen an und aus jedoch muss der collider noch für die kamera eingestellt werden,
    //wenn ein neuer camcollider aktiviert wird ist er nicht bei der Camera registriert und das muss geändert werden



    public GameObject[] enemies;
    public BoxCollider2D camCollider;
    private bool isColliderActive = false;
    private Collider2D camPolygonCollider;
    public CinemachineConfiner camConfiner;

    public bool roomIsClear = false;
    // Start is called before the first frame update
    void Start()
    {

        camConfiner = GameObject.FindGameObjectWithTag("CameraBrain").GetComponent<CinemachineConfiner>();
        camPolygonCollider = this.transform.parent.GetComponent<CompositeCollider2D>();
        camCollider = this.transform.parent.GetComponent<BoxCollider2D>();

        if (this.transform.parent.gameObject.CompareTag("EntryCamCollider"))
        {
             isColliderActive = true;
        }
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


    private void OnTriggerEnter2D(Collider2D collision)
    {

        
  

        if(collision.CompareTag("Player") == true && roomIsClear == true)
        {
            if(isColliderActive == true)
            {
                camCollider.enabled = false;
                isColliderActive = false;
            }
            else if(isColliderActive == false)
            {
                camConfiner.m_BoundingShape2D = camPolygonCollider;
                camCollider.enabled = true;
                isColliderActive = true;
            }
           
        }

    }
}
