using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //varaiable declaration
    Rigidbody2D rb;

    public GameObject myPlayer;

    private Animator anim; //animator setup

    public PlayerCombat Combat; // to use varables in PlayerCombat
    float moveLimiter = 0.7f;
    public float runSpeed = 10.0f;

    float vertical;
    float horizontal;

    private bool rotation = true;

    public float Speed = 10.0F; 

    void Awake()
    {
        anim = GetComponent<Animator>(); // setting up animator
    }


    void Start() // variable initialisation
    {
        rb = GetComponent<Rigidbody2D>(); // rb variable
    }

    void Update() //Maps keypresses to variables with values between -1 and 1 (executed every frame)
    {
        if (Combat.attacking)
        {
            runSpeed = 2F;
        }
        else
        {
            runSpeed = Speed;
            anim.SetBool("canWalk", true);
        }

        float horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        float vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        Vector3 movement = new Vector3(horizontal, vertical, 0.0F);

        movement.Normalize();

        transform.Translate(movement * runSpeed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero && Combat.attacking == false)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }


    }

    void FixedUpdate() //Convertes values to a vector (runs every physics-update)
    {

        if(Input.GetMouseButton(0) && rotation == true)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //mouse on gamescreen (main camera)

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //calculate rotation angle

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ); //rotating the player
        }
        
      


        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
        }

        rb.velocity = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0);
        
    }

    public void EnableRotation()
    {
        rotation = true;
    }

    public void DisableRotation()
    {
        rotation = false;
    }
}