using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public bool dirtyRazor = false;//looks wether the Item "Dirty Razor" has been picked up
    public float playerDamage = 30;
    public float playerMovementSpeed = 15;
    public float CurrExp = 0; //displays the whole amount of Exp you have
    public float GainedExp; //experience you gained just recently in a room and gets added to CurrExp as soon as possible. Enemys add a value to this when they are killed.
    public float health = 100;
    public float maxHealth = 100;
    private int levelsUntilBossfight = 7;
    public int[] sceneOrder;
    private int bossLevelSceneIndex = 2; // contains the Index of the scene for the bossfight
    public int currentArrayIndex = 0;
    public int nextScene;
    public int currentScene;
    public bool pause;
    GameObject levelSwitch;
    LevelSwitcher doorScript;

    public bool[] enabledSkills = new bool[24];
    public int xpLevel = 5;
    public float enemySpeed = 1.0f;
    public bool dash = false;
    public float enemyAttackSpeed = 1.0f;
    public bool enemyFreeze = false;
    public bool firstStrike = true;
    public bool combo = false;
    public float crit = 0f;
    public bool shock = false;
    public float attackDuration = 1.0f;
    public float healthGainFactor = 1.0f;
    //public float regeneration = 10f; // PROBLEME!!! keine Ahnung wieso -> deshalb neue Variable regen, funktioniert super
    public float armor = 0.0f;
    public bool shield = false;
    public bool lifeSaver = false;
    public float thorns = 0.0f;
    public float lifeSteal = 0.0f;
    public float regen = 0f; 

    public GameObject skilltree;



    public GameObject loadingScreen;

    // Awake is called before Start
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneOrder = new int[levelsUntilBossfight + 2];
        sceneOrder[0] = 1; //Set the Main Menu as the first scene.
        for (int i = 1; i <= (levelsUntilBossfight); i++) //generate random room sequence
        {
            sceneOrder[i] = Random.Range(3, SceneManager.sceneCountInBuildSettings);
        }
        sceneOrder[levelsUntilBossfight + 1] = bossLevelSceneIndex; //Adds the boss level as the last level


    }
    public void Update()// Update is called once per frame
    {
        if(GameObject.FindWithTag("Enemy") == null && currentArrayIndex > 0)
        {
           doorScript.OpenDoor();
            Debug.Log("Door Open?");
        }
        //Destroy(this.GameObject.FindGameObjectsWithTag("Enemy"))
        if (Input.GetKeyDown("n"))
        {
            NextScene();
        }

        health += (float)(regen * Time.deltaTime); // updates the players health by the regeneration per frame
        
    }

    /*
     *MethodenName: ItemController
     *public void ItemController(String int)
     *{
     *   switch case String()
     *   {
     *      Case Item1
     *      {
     *          zu ver�ndernde Variable; zB MoveSpeed += 10 * int; // Die cases m�ssen f�r Jedes Item erstellt werden
     *          in ItemsSinceCheckpoint String speichern // ItemsSinceCheckpoint wird oben (dei den Variable) deklariert
     *      }
     *      
     *   }
     *}
     *public void respawn()
     *{
     *  for (i = 0, i < ItemsSinceCheckpoint length, i++)
     *  {
     *      ItemController (ItemsSinceCheckpoint [i], -1);
     *  }
     *  
     *}
     *public void Checkpoint ()
     *{
     *  if (mathf.modulo(currentArrayIndex, 3) == 0)
     *  {
     *      ItemsSinceCheckpoint = {};
     *  }
     *  
     *}
     *
     *
     */

    public void PauseGame(bool pauseRequested)
    {
        if (pauseRequested)
        {
            Time.timeScale = 0;
            pause = true;
        } else
        {
            Time.timeScale = 1;
            pause = false;
        }
    }

    
    
    /*
     * old version without implemented loading screen
     * 
    public void NextScene()
    {
        nextScene = sceneOrder[currentArrayIndex + 1];
        SceneManager.LoadScene(nextScene);
        currentArrayIndex++;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    */

    // - - - - - - - - - - - - - - CODE BELOW THIS LINE IS STILL WORK IN PROGRESS - - - - - - - - - - - - - - -

    public void NextScene()
    {
        /*
         * Checkpoint();
         * 
         */
        //skilltree.SetActive(true);
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        nextScene = sceneOrder[currentArrayIndex + 1]; //pulls next scene from randomized array index
        currentArrayIndex++;
        //currentScene = SceneManager.GetActiveScene().buildIndex; //gets current scene build index 
        StartCoroutine(LoadLevelAsync()); //start async loading

    }

    public void LoadReferences(GameObject obj)
    {
        Debug.Log("references Loaded");
        doorScript = obj.GetComponent<LevelSwitcher>();
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }

        if (asyncLoad.isDone)
        {
            //currentArrayIndex++;
            currentScene = SceneManager.GetActiveScene().buildIndex; //gets current scene build index 
            if (loadingScreen != null)
            {
                loadingScreen.SetActive(false);
            }
        }
        
    }
}
