using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    GameObject dataManager; //Variable declaration
    DDOL gameController;
    //public static void IgnoreLayerCollision(int layer1 = 9, int layer2 = 7, bool ignore = true);

    // Start is called before the first frame update
    void Start()
    {

        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);


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
                gameController.health -= 20;
                
            }
        }

        if ( (other.gameObject.tag == "Wall" )||(other.gameObject.tag == "Player") )
        {
            Destroy(this.gameObject); // destroys the Bullet if it collides with player or wall
        }
        
    }
}

