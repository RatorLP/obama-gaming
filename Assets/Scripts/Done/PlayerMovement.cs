using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //varaiable declaration
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    void Start() //rb variable initialisation
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() //Maps keypresses to variables with values between -1 and 1 (executed every frame)
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

    }

    void FixedUpdate() //Convertes values to a vector (runs every physics-update)
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0);
    }
}