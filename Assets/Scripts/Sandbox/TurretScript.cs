using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TurretScript : MonoBehaviour
{
    GameObject dataManager; //Variable declaration
    DDOL gameController;
    public float Range; // Range of the enemy
    public Transform Target; // the enemy's target
    bool Detected = false; // looks wether Player is detected or not

    public GameObject Gun; // Creates the Gun; the Gun does not have Code itself
    public GameObject Bullet; // Creates the Object for the Bullet
    public Transform shootingPoint; // the Point from which the enemy shoots the Bullets
    public float FireRate; // attackinterval of the Enemy
    float nextTimeToShoot = 0; // an additional Variable to determine the attackinterval of the enemy
    public float Force; // determines the speed and Travel time of the Bullet
    Vector2 Direction; // determines and calculates the direction in which the enemy shoots

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position; // takes the position of the Player

        Direction = targetPos - (Vector2)transform.position; // calculates the diraction in which the enemy shoots

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range, 7); // casts a line in a direction and looks if something is hit by this line

        if (rayInfo) // Information of the line
        {
            if (rayInfo.collider.gameObject.tag == "Wall") // looks if the line hits the Player, if yes, "Detected" is set to true, if the player is not detected anymore "Detected" is set to false
            {
                
                Detected = false;

            }
            else
            {
                Detected = true;
            }
        }
        if (Detected = true) // if the player is detected the enemy shoots
        {
            Gun.transform.right = Direction; // insures the gun is rotated the right way
            if (Time.time > nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1 / FireRate; // calculates how fast the enemy shoots
                shoot();
            }
        }
    }
    void OnDrawGizmosSelected() // draws the range of the enemy
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    void shoot() // the Bullet is shot out via constantly replicating the bullet per every Frame
    {
        GameObject BulletIns = Instantiate(Bullet, shootingPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force); // calculates the speed of the Projectile
    }
    void OnCollisionEnter2D(Collision2D other) // Method to check wether something is hit or not
    {
        if (GameObject.Find("DataManager") == null)
        { // returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            SceneManager.LoadScene(0);
            return;
        }
    }

}
