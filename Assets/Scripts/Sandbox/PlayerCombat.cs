using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Variable decleration
    public Transform attackPoint; //The point at which the sword hits
    public Transform attackRange; // the Range of the melee attack
    public LayerMask NPCLayers; //Determines what is hit by using Layers
    public CapsuleDirection2D attackDirection; // direction of sides wich can be extended
    public float attackAngle; //angle of the roation the capsule has

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //calls the "Attack" method
        {
            Attack();
        }
    }


    void Attack() //looks whether there is an overlap in the circle, then safes whatever is overlapping in an array and then hits the enemy
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCapsuleAll(attackPoint.position, attackRange.position, attackDirection, attackAngle, NPCLayers);

        foreach (Collider2D NPC in hitEnemies)
        {
            Debug.Log("hit");
        }
    }

    void OnDrawGizmosSelected() //draws the range of the attack; only for testing purposes, will be deleted later
    {
        Gizmos.DrawWireSphere(attackPoint.position, 0.5F);
    }
}
