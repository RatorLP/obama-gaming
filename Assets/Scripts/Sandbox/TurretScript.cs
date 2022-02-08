using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float Range; // Range of the enemy

    public Transform Target; // the enemy's target

    bool Detected = false; // looks wether Player is detected or not

    public GameObject Gun; // Creates the Gun; the Gun does not have Code itself

    public GameObject Bullet; // Creates the Object for the Bullet

    public Transform shootingPoint; // the Point from which the enemy shoots the Bullets

    public float FireRate; // attackinterval of the Enemy

    float nextTimeToShoot = 0; // an additional Variable to determine the attackinterval of the enemy

    public float Force; // determines the speed and Travel time of the Bullet

    Vector2 Direction; // determines the and calculates the direction in which the enemy shoots

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position; // takes the position of the Player

        Direction = targetPos - (Vector2)transform.position; // calculates the diraction in which the enemy shoots

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range); // casts a line in a direction and looks if something is hit by this line

        if (rayInfo) // Information of the line
        {
            if (rayInfo.collider.gameObject.tag == "Player") // looks if the line hits the Player, if yes, "Detected" is set to true, if the player is not detected anymore "Detected" is set to false
            {
                if (Detected == false) 
                {
                    Detected = true;
                }

            }
            else if (Detected == true)
            {
                Detected = false;
            }
        }
        if (Detected) // if the player is detected the enemy shoots
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
}
