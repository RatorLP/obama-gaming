using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attackHitbox : MonoBehaviour
{
    GameObject dataManager;
    DDOL gameController;
    public Damage Enemy;

    void Start()// Start is called before the first frame update
    {
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
    }

    void OnTriggerEnter2D(Collider2D other) //if the player is in the attack hitbox, the player gets hit for a set amount
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameController.shield) //if shield is active 
            {
                if (gameController.shieldDurability >= Enemy.damage * gameController.shieldAbsorption) //if shield is in good condition reduce player damage. If armor is skilled reduce player damage further
                {
                    gameController.shieldDurability -= Enemy.damage * gameController.shieldAbsorption;
                    gameController.health -= Enemy.damage * (1 - gameController.shieldAbsorption) * (1 - gameController.armor);
                }
                else //if shield is in bad condition let the shield absorb as much of the attack as possible, deal the rest as damage to the player. Limit damage further through the armor
                {
                    gameController.health -= (Enemy.damage - gameController.shieldDurability) * (1 - gameController.armor);
                    gameController.shieldDurability = 0;
                }
            }
            else //if shield isn't skilled, deal damage only limited by armor
            {
                gameController.health -= Enemy.damage * (1 - gameController.armor);
            }
        }
    }

}

