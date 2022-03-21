using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtingenemys : MonoBehaviour
{
    public float ExpDrop; //displays the amount of Exp gained when killing this enemy
    public float MaxHp; //displays the maxium amount of HP you can have
    float CurrHp; //displays your current amount HP in natural numbers

    GameObject dataManager; //Variable declaration
    DDOL gameController;

    // Start is called before the first frame update
    void Start()
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

    public void TakeDmg(float gotteddmg)
    {
        SoundManager.PlaySound("EnemyHitSound");
        CurrHp -= gotteddmg;
        

        if (CurrHp <= 0)// destroys the Enemy if it's health reaches zero
        {
            SoundManager.PlaySound("EnemyDeathSound");
            Destroy(this.gameObject);
            gameController.GainedExp = ExpDrop; //adds the Xp to the player
        }
    }



}
