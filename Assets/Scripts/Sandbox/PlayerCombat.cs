using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Variable decleration
    public Transform attackPoint; //The point at which the sword hits
    public float attackRange = 0.5f; // the Range of the melee attack
    public LayerMask NPCLayers; //Determines what is hit by using Layers

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //calls the "Attack" method
        {
            Attack();
        }
    }


    void Attack() //looks whether there is an overlap in the circle, then safes whatever is overlapping in an array and then hits the enemy
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, NPCLayers);

        foreach (Collider2D NPC in hitEnemies)
        {
            Debug.Log("hit");
        }
    }

    void OnDrawGizmosSelected() //draws the range of the attack; only for testing purposes, will be deleted later
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
