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

    public float attackRange;
    public float attackTimer;

    private bool attackMode;
    public bool inRange = false;
    private bool attackCooling = false;
    private float IntTimer;
    private Animator anim;

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
            anim.SetBool("canWalk", true);
        }
    }

    void Attack()
    {
        attackTimer = IntTimer; //reset timer when player enters attack range
        attackMode = true; //to check if enemy can still attack

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);


    }

    void Cooldown()
    {
        IntTimer -= Time.deltaTime;

        if (attackTimer <= 0 && attackCooling && attackMode)
        {
            attackCooling = false;
            attackTimer = IntTimer;
        }
    }


    void StopAttack()
    {
        attackCooling = false;
        attackMode = false;

        anim.SetBool("Attack", false);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        inRange = false;
    }

    public void TriggerCooling()
    {
        attackCooling = true;
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

        void OnCollisionEnter2D(Collision2D other) // Method to check wether something is hit or not
        {
            if (GameObject.Find("DataManager") == null)
            { // returns if the data manager doesn't exist
                Debug.Log("dataManager not found");
                SceneManager.LoadScene(0);
                Debug.Log("Load Scene 0");
                return;
            }

            foreach (ContactPoint2D hitPos in other.contacts)
            {
                if (other.gameObject.tag == "Player")
                {
                    gameController.health -= damage;
                    CurrHp -= gameController.playerDamage;
                }

                if (CurrHp <= 0)// destroys the Enemy if it's health reaches zero
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}