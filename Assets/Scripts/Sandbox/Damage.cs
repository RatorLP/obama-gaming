using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{

    GameObject dataManager; //Variable declaration
    DDOL gameController;
    float MaxHp = 100; //displays the maxium amount of HP you can have
    float CurrHp; //displays your current amount HP in natural numbers
    public int damage;

    //public float attackRange;
    public float attackTimer;
    //public float rayCastLength;
    //public Transform rayCast;
    //public LayerMask raycastMask;

    //public RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    public bool inRange = false;
    public bool attackCooling = false;
    private float IntTimer;
    

    void Awake()
    {
        IntTimer = attackTimer;
        anim = GetComponent<Animator>();
    }

    void Start()// Start is called before the first frame update
    {
        CurrHp = MaxHp;
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            Debug.Log("Load Scene 0");
            SceneManager.LoadScene(0);
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true && attackCooling == false)
        {
            Attack();
        }

        if (inRange == false)
        {
            StopAttack();
        }

        if (attackCooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
            anim.SetBool("canWalk", true);
        }

        if (gameController.dashing)
        {
            if (gameObject.GetComponent<CircleCollider2D>() != null)
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            if (gameObject.GetComponent<CapsuleCollider2D>() != null)
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            if (gameObject.GetComponent<CircleCollider2D>() != null)
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
            if (gameObject.GetComponent<CapsuleCollider2D>() != null)
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }


    void Attack()
    {
        attackTimer = IntTimer; //reset timer when player enters attack range
        //attackMode = true; //to check if enemy can still attack

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);


    }


    void Cooldown()
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

    public void TriggerCooling()
    {
        attackCooling = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameController.shield) //if shield is active 
            {
                if (gameController.shieldDurability >= (damage) * gameController.shieldAbsorption)
                {
                    gameController.shieldDurability -= (damage) * gameController.shieldAbsorption;
                    gameController.health -= damage * (1 - gameController.shieldAbsorption);
                }
                else
                {
                    gameController.health -= (damage - gameController.shieldDurability);
                    gameController.shieldDurability = 0;
                }
            }
            else
            {
                gameController.health -= damage;
            }
        }
    }

    public void DamageOverTime(int damageAmount, int damageTime)
    {
        if (gameController.dirtyRazor = true)
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