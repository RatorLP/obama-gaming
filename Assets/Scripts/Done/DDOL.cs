using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public bool dirtyRazor = false;//looks wether the Item "Dirty Razor" has been picked up
    public float playerDamage = 30;
    public float playerMovementSpeed = 15;
    public float health = 100;
    public float maxHealth = 100;
    public int levelsUntilBossfight = 100;
    public int[] sceneOrder;
    private int bossLevelSceneIndex = 0; // contains the Index of the scene for the bossfight
    private int currentArrayIndex = 0;
    public int nextScene;
    public int currentScene;
    public bool pause;

    public bool[] enabledSkills = new bool[24];
    public int xpLevel = 100;
    public double enemySpeed = 1.0;
    public bool dash = false;
    public double enemyAttackSpeed = 1.0;
    public bool enemyFreeze = false;
    public bool firstStrike = false;
    public bool combo = false;
    public double crit = 1;
    public bool shock = false;
    public double attackDuration = 1.0;
    public double healthGainFactor = 1.0;
    //public float regeneration = 10f; // PROBLEME!!! keine Ahnung wieso -> deshalb neue Variable regen, funktioniert super
    public double armor = 0.0;
    public bool shield = false;
    public bool liveSafer = false;
    public double thorns = 0.0;
    public double liveSteal = 0.0;
    public float regen = 0f; 



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
            sceneOrder[i] = Random.Range(2, SceneManager.sceneCountInBuildSettings);
        }
        sceneOrder[levelsUntilBossfight + 1] = bossLevelSceneIndex; //Adds the boss level as the last level


    }
    public void Update()// Update is called once per frame
    {
        if (Input.GetKey("n"))
        {
            NextScene();
        }

        health += (float)(regen * Time.deltaTime); // updates the players health by the regeneration per frame
        Debug.Log(regen);
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
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        nextScene = sceneOrder[currentArrayIndex + 1]; //pulls next scene from randomized array index
        //currentArrayIndex++;
        //currentScene = SceneManager.GetActiveScene().buildIndex; //gets current scene build index 
        StartCoroutine(LoadLevelAsync()); //start async loading

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
            currentArrayIndex++;
            currentScene = SceneManager.GetActiveScene().buildIndex; //gets current scene build index 
            if (loadingScreen != null)
            {
                loadingScreen.SetActive(false);
            }
        }
        
    }
}
