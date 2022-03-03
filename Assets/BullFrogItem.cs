using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BullFrogItem : MonoBehaviour
{
    GameObject dataManager; //Variable declaration
    DDOL gameController;


    // Start is called before the first frame update
    void Start()
    {
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

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            SceneManager.LoadScene(0);
            return;
        }
        foreach (ContactPoint2D hitPos in other.contacts)
        {
            if (other.gameObject.tag == "Player") //The amount of damage the player deals after picking up the Item
            {
                gameController.maxHealth += 20;
                gameController.playerMovementSpeed -= 10;
                gameController.playerDamage += 5;
                //gameControllerPlayerSize += 5; oderso wir müssen die Variable noch hinzufügen, ändert einfach nur Size vom Player
                Debug.Log("you feel Angery and BIG");
                Debug.Log(gameController.maxHealth + " " + gameController.playerMovementSpeed + " " + " " + gameController.playerDamage);
                Destroy(this.gameObject);
            }
        }
    }
}
