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
        
        if (GameObject.Find("DataManager") == null)
        { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object

        if (GameObject.Find("DataManager") == null)
        { // returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            SceneManager.LoadScene(0);
            Debug.Log("Load Scene 0");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.health -= Enemy.damage * (1-gameController.armor);
        }
    }

}

