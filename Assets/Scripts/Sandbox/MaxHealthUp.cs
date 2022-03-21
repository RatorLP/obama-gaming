using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MaxHealthUp : MonoBehaviour
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
            if (other.gameObject.tag == "Player") //changes player stats
            {
                gameController.maxHealth += 30; //increases maximum Health
                gameController.health += 40; //heals the player for a set amount
                Debug.Log("Deine HP:" + gameController.health + "Deine MaxHP:" +  gameController.maxHealth);
                Destroy(this.gameObject);
            }
        }
    }
}
