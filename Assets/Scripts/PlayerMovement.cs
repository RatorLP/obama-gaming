using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //varaiable declaration
    Rigidbody2D rb;
    CircleCollider2D cc;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    bool wallL = false; //used for collision
    bool wallR = false;
    public bool wallU = false;
    public bool wallD = false;

    public float runSpeed = 20.0f;

    void Start() //rb variable initialisation
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();

    }

    void Update() //Maps keypresses to variables with values between -1 and 1 (executed every frame)
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        cc.radius = 0.5f;
    }

    void FixedUpdate() //Convertes values to a vector (runs every physics-update)
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        if (wallR && horizontal > 0){
            horizontal = 0;
        }
        if (wallL && horizontal < 0){
            horizontal = 0;
        }
        if (wallU && vertical > 0){
            vertical = 0;
        }
        if (wallD && vertical < 0){
            vertical = 0;
        }
        rb.velocity = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D other) //other is the second object involved in the collision
    {
        //collision.GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "Wall") 
        {
            //collision.GetContacts();
            foreach(ContactPoint2D hitPos in other.contacts)
            {
                //Debug.Log(hitPos.normal); //wall touched is... above=(0.0, -1.0) ; below=(0.0, 1.0) ; left=(1.0, 0.0); right=(-1.0, 0.0)
                if (hitPos.normal[0] < -0.5){
                    wallR = true;
                }
                if (hitPos.normal[0] > 0.5){
                    wallL = true;
                }
                if (hitPos.normal[1] < -0.5){
                    wallU = true;
                }
                if (hitPos.normal[1] > 0.5){
                    wallD = true;
                }
            } 
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        wallL = false;
        wallR = false;
        wallU = false;
        wallD = false;
    }
}