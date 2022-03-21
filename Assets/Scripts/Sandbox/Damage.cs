using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    float MaxHp = 100; //displays the maxium amount of HP (health) you can have
    float CurrHp; //displays your current amount of HP in natural numbers
    public int damage; //the amount of damage the enemy deals

    //public float attackRange;

    //public float rayCastLength;
    //public Transform rayCast;
    //public LayerMask raycastMask;

    //public RaycastHit2D hit;
    
    public bool inRange = false; //set to true when the player enters the attack radius
    public bool attackCooling = false; //is true during cooldown. while this is true no attack can be executed

    private float IntTimer; //holds the cooldown time to reset attackTimer
    public float attackTimer; //keeps the time between atacks to limit attack speed

    private Animator anim; //adds base for animations

    GameObject dataManager;
    DDOL gameController;


    void Awake()//Awake is called before start
    {
        IntTimer = attackTimer; //attack speed for the enemy
        anim = GetComponent<Animator>(); //gets a reference to the animator
    }

    void Start()// Start is called before the first frame update
    {
        CurrHp = MaxHp;

        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && attackCooling == false) //as long as the player is in and the attack is aviable, the enemy attacks
        {
            Attack();
        }

        if (inRange == false) //stop attacking, if the player is not in range anymore
        {
            StopAttack();
        }

        if (attackCooling) //attack speed
        {
            Cooldown();
            anim.SetBool("Attack", false);
            anim.SetBool("canWalk", true);
        }

        if (gameController.dashing) //disables collision with player if the player is dashing
        {
            if (gameObject.GetComponent<BoxCollider2D>() != null)
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (gameObject.GetComponent<CapsuleCollider2D>() != null)
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            if (gameObject.GetComponent<BoxCollider2D>() != null)
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if (gameObject.GetComponent<CapsuleCollider2D>() != null)
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }


    void Attack()
    {
        attackTimer = IntTimer; //reset timer when player enters attack range

        anim.SetBool("canWalk", false); //plays the Attack animation
        anim.SetBool("Attack", true);
    }


    void Cooldown() //cooldown between attacks
    {
        attackTimer -= (Time.deltaTime * gameController.enemyAttackSpeed);

        if (attackTimer <= 0 && attackCooling)
        {
            attackCooling = false;
            attackTimer = IntTimer;
        }
    }


    void StopAttack()
    {
        //attackMode = false;
        anim.SetBool("Attack", false);
        anim.SetBool("canWalk", true);
    }

    /*
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
    */


    /*void RaycastDebugger()
    {
       Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
    }
    */

    public void TriggerCooling() //gets called by the animation after the animation finishes
    {
        attackCooling = true;
    }

    void OnCollisionEnter2D(Collision2D other) //deals damage to the player
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameController.shield) //if shield is active 
            {
                if (gameController.shieldDurability >= damage * gameController.shieldAbsorption) //if shield is in good condition reduce player damage. If armor is skilled reduce player damage further
                {
                    gameController.shieldDurability -= damage * gameController.shieldAbsorption;
                    gameController.health -= damage * (1 - gameController.shieldAbsorption) * (1 - gameController.armor);
                }
                else //if shield is in bad condition let the shield absorb as much of the attack as possible, deal the rest as damage to the player. Limit damage further through the armor
                {
                    gameController.health -= (damage - gameController.shieldDurability) * (1 - gameController.armor);
                    gameController.shieldDurability = 0;
                }
            }
            else //if shield isn't skilled, deal damage only limited by armor
            {
                gameController.health -= damage * (1 - gameController.armor);
            }
        }
    }

    public void DamageOverTime(int damageAmount, int damageTime) //adds damage over time to the enemy, if the player picks up the item "dirty razor"
    {
        if (gameController.dirtyRazor)
        {
            StartCoroutine(DamageOverTimeCoroutine(damageAmount, damageTime));
        }

        IEnumerator DamageOverTimeCoroutine(float damageAmount, float duration)
        {
            float amountDamaged = 0;
            float damagePerLoop = damageAmount / duration;
            while (amountDamaged < damageAmount)
            {
                CurrHp -= damagePerLoop;
                Debug.Log(CurrHp);
                amountDamaged += damagePerLoop;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}