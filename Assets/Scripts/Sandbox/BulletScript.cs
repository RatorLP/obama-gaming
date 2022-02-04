using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Damage; // The Variable for Damage done to the player

    // Start is called before the first frame update
    void Start()
    {
        Damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D Col) // Method to chech wether something is hit or not
    {
        Destroy(this.gameObject); // destroys the Bullet if it collides woth something
    }
}
