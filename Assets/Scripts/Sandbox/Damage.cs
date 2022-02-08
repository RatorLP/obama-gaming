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

    }
    void OnCollisionEnter2D(Collision2D other) // Method to check wether something is hit or not
    {
        if (GameObject.Find("DataManager") == null)
        { // returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            SceneManager.LoadScene(0);
            return;
        }
        foreach (ContactPoint2D hitPos in other.contacts)
        {
            if (other.gameObject.tag == "Player")
            {
                gameController.health -= damage;
                CurrHp -= gameController.playerDamage;


            }
            if (CurrHp <= 0)// destroys the Enemy if it's helth reaches zero
            {
                Destroy(this.gameObject);
            }
        }

    }
}