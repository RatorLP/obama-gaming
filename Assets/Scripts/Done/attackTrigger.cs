using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public Damage Enemy;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trig) //if the player is in range, the enemy attacks
    {
        if (trig.gameObject.tag == "Player")
        {
            Enemy.inRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D trig) //if the player is no longer in range, the enemy will no longer attack
    {
        if (trig.gameObject.tag == "Player")
        {
            Enemy.inRange = false;
        }
    }
}
