using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //varaiable declaration
    Rigidbody2D rb;

    //float Speed = gameController.playerMovementSpeed;
    
    GameObject dataManager;
    DDOL gameController;

    public bool dashCooling = false;
    private float dashTimer;
    
    public GameObject myPlayer;

    private Animator anim; //animator setup

    public PlayerCombat Combat; // to use varables in PlayerCombat
    float moveLimiter = 0.7f;
    public float tempSpeed = 10.0f;

    float vertical;
    float horizontal;

    private bool rotation = true;

    public float moveSpeed;
    private bool dashing;
    private float dashTime;

    void Awake()
    {
        anim = GetComponent<Animator>(); // setting up animator
    }


    void Start() // variable initialisation
    {
        rb = GetComponent<Rigidbody2D>(); // rb variable
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
        
    }

    void Update() //Maps keypresses to variables with values between -1 and 1 (executed every frame)
    {
        dashTime += Time.deltaTime;

        moveSpeed = gameController.playerMovementSpeed;
        tempSpeed = moveSpeed;
        
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Combat.attacking) //slows down the movement speed of the player, to make the attack smoother
        {
            tempSpeed = 2F;
        }
        else if (horizontal != 0 || vertical != 0)
        {
            //tempSpeed = moveSpeed;
            anim.SetBool("canWalk", true);
        }
        else
        {
            anim.SetBool("canWalk", false);
        }
        if (gameController.dash && Input.GetKeyDown("space")) //ads a dash to the player. This is a Skill implementation
        {
            dashing = true;
            gameController.dashing = true;
            dashTime = 0;
            //gameObject.GetComponent<CircleCollider2D>().enabled = false;

            

        }
        if(dashing)
        {
            tempSpeed = 50f;
            if (dashTime > 0.1f)
            {
                dashing = false;
                gameController.dashing = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                dashCooling = true; // aktiviert cooldown für dash
            }
        }

        if(dashCooling) //cooldown between dashes
        {
            gameController.dash = false;

            dashTimer += Time.deltaTime;

            if (dashTimer > 2F)
            {
                gameController.dash = true;
                dashCooling = false;
                dashTimer = 0F;
            }
        }

        if (Combat.attacking == false)
        {
              anim.SetFloat("horizontal", horizontal);
              anim.SetFloat("vertical", vertical);
        }

        if (Input.GetMouseButton(0) && rotation == true) //rotates the player in the melee direction
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //mouse on gamescreen (main camera)

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //calculate rotation angle

            anim.SetFloat("horizontal", (difference.x / 100));
            anim.SetFloat("vertical", (difference.y / 100));

        }

        /*Vector3 movement = new Vector3(((-1)*vertical), horizontal, 0.0F);

        movement.Normalize();

        if (movement != Vector3.zero && Combat.attacking == false)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
        */

    }

    void FixedUpdate() //Convertes values to a vector (runs every physics-update)
    {

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
        }

        rb.velocity = new Vector3(horizontal * tempSpeed, vertical * tempSpeed, 0);
        
    }

    public void EnableRotation()
    {
        rotation = true;
    }

    public void DisableRotation()
    {
        rotation = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            SceneManager.LoadScene(0);
            return;
        }
        
    }

}