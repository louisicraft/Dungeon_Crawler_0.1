using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Rigidbody
    public Rigidbody2D rb;
    //Speed
    public float moveSpeed = 0.25f;
    public float sprintSpeed;

    private float realMoveSpeed;
    private Vector2 movement;


    void Update()
    {
       
        Rotation();
    }

    void FixedUpdate()
    {
      
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realMoveSpeed = sprintSpeed;
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movement * realMoveSpeed);// = new Vector2(realMoveSpeed * horizontalMove, realMoveSpeed * verticalMove);
      

        realMoveSpeed = moveSpeed;
    }
    private void Rotation()
    {
       
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = Mathf.Atan2(transform.position.y - mouseOnScreen.y, transform.position.x - mouseOnScreen.x) * Mathf.Rad2Deg;
        

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));
    }
}
