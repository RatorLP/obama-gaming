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
    public float attackTimer; //attackspeed
    public bool attackCooling = false; // cooldown activation
    public bool attacking; // if player is currently attacking

    private float IntTimer; //actual timer
    private Animator anim; //animator setup


    void Awake() //called before first frame
    {
        IntTimer = attackTimer;
        anim = GetComponent<Animator>(); // setting up animator
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);

        }

        if (Input.GetMouseButtonDown(0) && attackCooling == false) //calls the "Attack" method when mousebutton is pressed
        {
            Attack();
        }
    }


    void Attack() //looks whether there is an overlap in the circle, then safes whatever is overlapping in an array and then hits the enemy
    {
        attackTimer = IntTimer; //reset timer when new attack starts

        attacking = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);

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

    void Cooldown()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0 && attackCooling)
        {
            attackCooling = false;
            attackTimer = IntTimer;

        }
    }

    public void TriggerCooling()
    {
        attackCooling = true;
    }

    public void FinishedAttack()
    {
        attacking = false;
    }
}
