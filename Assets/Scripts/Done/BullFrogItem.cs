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
            if (other.gameObject.tag == "Player") //changes player stats(statistics)
            {
                SoundManager.PlaySound("ItemPickupSound");
                gameController.maxHealth += 20; //increases maximum health (Hp)
                gameController.playerMovementSpeed -= 5; //reduces movement speed
                gameController.playerDamage += 5; //increases attack damage
                Debug.Log("you feel Angery and BIG");
                Debug.Log(gameController.maxHealth + " " + gameController.playerMovementSpeed + " " + " " + gameController.playerDamage); //displays all newly gained statistics
                Destroy(this.gameObject); //removes object, so it does not interfere
            }
        }
    }
}
