using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDDOL : MonoBehaviour
{
    GameObject cam;
    DDOL gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dataManager = GameObject.Find("DataManager");
        DDOL gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
        //access global variables using: gameControler.[variableName]
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
