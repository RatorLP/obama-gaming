using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDDOL : MonoBehaviour
{
    GameObject dataManager;
    DDOL gameController;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("DataManager") == null) {//returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
        //access global variables using: gameControler.[variableName]
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
