using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public bool dirtyRazor = false;//looks wether the Item "Dirty Razor" has been picked up
    public float playerDamage = 30;
    public float playerMovementSpeed = 15;
    public int health = 100;
    public int maxHealth = 100;
    public int levelsUntilBossfight = 100;
    public int[] sceneOrder;
    private int bossLevelSceneIndex = 0; // contains the Index of the scene for the bossfight
    private int currentArrayIndex = 0;
    public int nextScene;
    public int currentScene;
    public bool pause;
    public int[] skillA = new int[4];
    public int[] skillB = new int[4];
    public int[] skillC = new int[4];
    public int[] skillD = new int[4];


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
    }

    /*
     *MethodenName: ItemController
     *public void ItemController(String int)
     *{
     *   switch case String()
     *   {
     *      Case Item1
     *      {
     *          zu verändernde Variable; zB MoveSpeed += 10 * int; // Die cases müssen für Jedes Item erstellt werden
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

    public void Skill(string newSkill)
    {
        if (newSkill[0] == 'A')
        {
            skillA[newSkill[1]] = 1;
        }
        if (newSkill[0] == 'B')
        {
            skillB[newSkill[1]] = 1;
        }
        if (newSkill[0] == 'C')
        {
            skillC[newSkill[1]] = 1;
        }
        if (newSkill[0] == 'D')
        {
            skillD[newSkill[1]] = 1;
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
