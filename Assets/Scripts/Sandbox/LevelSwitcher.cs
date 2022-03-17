using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    GameObject dataManager; //Variable declaration
    DDOL gameController;
    int[] sceneOrder;
    int currentScene;
    int nextScene;
    private SpriteRenderer spriteRenderer;
    public Sprite openedDoor;
    private bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
       
        spriteRenderer = gameObject.GetComponent <SpriteRenderer>();
        if (GameObject.Find("DataManager") == null) { //returns if the data manager doesn't exist
            Debug.Log("dataManager not found");
            return;
        }
        dataManager = GameObject.Find("DataManager");
        gameController = dataManager.GetComponent<DDOL>(); //gets a reference for the "DDOL" script which is attached to the "DataManager" object
        gameController.LoadReferences(gameObject);
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
            if (other.gameObject.tag == "Player" && doorOpen)
            {
                gameController.NextScene();
            }
        }
    }
    public void OpenDoor()
    {
        doorOpen = true;
        spriteRenderer.sprite = openedDoor;
    }
}
