using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class USBItemScript : MonoBehaviour
{
    GameObject dataManager; //Variable declaration
    DDOL gameController;

    //Start is called before the first frame update
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

    //Update is called once per frame
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
            if (other.gameObject.tag == "Player") //changes player statistics
            {
                SoundManager.PlaySound("ItemPickupSound");
                gameController.playerMovementSpeed += 3; //increases movement speed of the player
                Debug.Log("Time to Sped" + gameController.playerMovementSpeed);
                Destroy(this.gameObject); //removes object, so it does not interfere with gameplay
            }
        }
    }
}