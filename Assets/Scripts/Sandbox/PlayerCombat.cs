using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Variable decleration
    public Transform attackPoint; // The point at which the sword hits
    public float attackRange = 0.5f; // the Range of the melee attack
    public LayerMask NPCLayers; // Determines what is hit by using Layers
    private float attackTimer; // delay between attacks
    private bool attackCooling = false; // cooldown activation
    public bool attacking = false; // if player is currently attacking
    public float thrust;

    private float IntTimer; // actual timer
    private Animator anim; // animator setup

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

    void Awake() // called before first frame
    {
        IntTimer = attackTimer;
        anim = GetComponent<Animator>(); // setting up animator
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooling) // adds an attack speed for the player
        {
            Cooldown();
            anim.SetBool("Attack", false);

        }

        if (Input.GetMouseButtonDown(0) && attackCooling == false) // calls the "Attack" method when mousebutton is pressed
        {
            Attack();
        }

        
    }


    void Attack() // looks whether there is an overlap in the circle, then safes whatever is overlapping in an array and then hits the enemy
    {
        attackTimer = IntTimer; // reset timer when new attack starts
        Debug.Log("Hit?"); // for testing purposes. Displays the given String
        attacking = true;

        anim.SetBool("canWalk", false); // sets the animation
        anim.SetBool("Attack", true);

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, NPCLayers);

        foreach (Collider2D NPC in hitEnemies)
        {
            Knockback(NPC);
            calculateDamage();
            NPC.GetComponent<hurtingenemys>().TakeDmg(finalDamage); // calls the "TakeDmg" method from the "hurtingenemys" script
            Debug.Log("YOU HIT! You did: " +  finalDamage);
            gameController.health += gameController.lifeSteal * finalDamage; // adds Lifesteal skill. Heals the player for damage delt
        }
        
    }
    
    public void Knockback(Collider2D NPC)
    {
        Vector2 difference = NPC.gameObject.transform.position - gameObject.transform.position;
        difference = difference.normalized * thrust; //normalized means, that the Vector has a maximum of a length of 1
        Vector3 knockback = new Vector3(difference[0], difference[1], 0);
        NPC.gameObject.transform.position += knockback;
    }

    void calculateDamage() // calculates the final damage. This is used by the "FirstStrike" skill
    {
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
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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

    public void FinishedAttack() // sets animation to idle state, after the attack animatoin has finished
    {
        anim.SetBool("Attack", false);
        attacking = false;
    }

    public void triggerCooling() // adds a short period, where the player cannot attack
    {
        attackCooling = true;
        attacking = false;
    }

}
