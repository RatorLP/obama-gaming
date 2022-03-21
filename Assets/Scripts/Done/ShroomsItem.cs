using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShroomsItem : MonoBehaviour
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
        // currently not used in script
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
            if (other.gameObject.tag == "Player") //changes player statistics
            {
                SoundManager.PlaySound("ItemPickupSound");
                gameController.maxHealth -= 5; //reduces maximum health(Hp)
                gameController.playerDamage += 15; //increases player damage
                Debug.Log("Picked Up Shrooms, you feel kinda funny");
                Debug.Log(gameController.maxHealth) ;
                Destroy(this.gameObject); //removes object, as to not interfere with the game after pickup
            }
        }
    }
}
