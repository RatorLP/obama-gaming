using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Variable decleration
    public Transform attackPoint; //The point at which the sword hits
    public float attackRange = 0.5f; // the Range of the melee attack
    public LayerMask NPCLayers; //Determines what is hit by using Layers
    //public CapsuleDirection2D attackDirection; // direction of sides wich can be extended
   //public float attackAngle; //angle of the roation the capsule has
    private float attackTimer; //delay between attacks
    //public float PlayerDmg = 20; //Damage the player deals  (new version uses DDOL scripts playerDamege variable)
    private bool attackCooling = false; // cooldown activation
    public bool attacking = false; // if player is currently attacking

    //public Damage Enemy;

    private float IntTimer; //actual timer
    private Animator anim; //animator setup

    GameObject dataManager;
    DDOL gameController;

    // variables to calculate the final damage
    private float finalDamage;
    private float damageMultiplicator = 1f;
    private float firstStrikeCooldown = 5.0f;
    private bool firstStrikeAvailable = true;
    private float lastAttackTime = 0f;
    private float comboCooldown = 1.5f;
    private int comboCount = 0;
    

    void Start() // variable initialisation
    {
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object

    }

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
        Debug.Log("Hit?");
        attacking = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, NPCLayers);

        foreach (Collider2D NPC in hitEnemies)
        {
            calculateDamage();
            NPC.GetComponent<hurtingenemys>().TakeDmg(finalDamage);
            Debug.Log("TWAT, YOU HIT! You did: " +  finalDamage);
            gameController.health += gameController.lifeSteal * finalDamage;
        }
        
    }

    void calculateDamage() {
        damageMultiplicator = 1f;
        if (comboCount < 5)
            comboCount += 1;
        if (Time.time - lastAttackTime > comboCooldown)
            comboCount = 0;
        if (Time.time - lastAttackTime >= firstStrikeCooldown)
            firstStrikeAvailable = true;

        if (Random.value <= gameController.crit) {
            damageMultiplicator += 1f;
        }
        if(firstStrikeAvailable && gameController.firstStrike) {
            
            damageMultiplicator += 0.5f;
        }
        if(Time.time - lastAttackTime <= comboCooldown)
        {
            damageMultiplicator += 0.5f * comboCount;
        }

        firstStrikeAvailable = false;
        lastAttackTime = Time.time;

        finalDamage = gameController.playerDamage * damageMultiplicator;

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

    public void FinishedAttack()
    {
        anim.SetBool("Attack", false);
        attacking = false;
    }

    public void triggerCooling()
    {
        attackCooling = true;
        attacking = false;
    }

}
