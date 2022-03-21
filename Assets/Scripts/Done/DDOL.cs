using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public bool dirtyRazor = false; //looks wether the Item "Dirty Razor" has been picked up
    public float playerDamage = 30; //the amount of Damage the player deals with every hit
    public float playerMovementSpeed = 15; //The Movement speed of the player
    public float CurrExp = 0; //displays the whole amount of Exp you have
    public float GainedExp; //experience you gained just recently in a room and gets added to CurrExp as soon as possible. Enemys add a value to this when they are killed.

    public float health = 100; //Stores the current health of the player
    public float maxHealth = 100; //The maximal amount of health the player can have
    private int levelsUntilBossfight = 7; //amount of levels the player has to get through to get to the boss
    public int[] sceneOrder; //Array storing the build indices (scene numbers) in a randomized order With The main menu as the first scene and boss fight as the last scene
    private int bossLevelSceneIndex = 2; //contains the build index (scene number) for the boss scene
    public int currentArrayIndex = 0; //stores the index of the array. This way it counts how many scenes you went through and ensures the correct order of scenes
    public int nextScene; //contains the build index (scene number) of the next scene
    public int currentScene; //contains the build number of the current scene
    public bool pause; //is true when the game is paused

    public bool[] enabledSkills = new bool[24]; //stores which skills are activated. order is: [a, b, c, ax, ay, bx, by, cx, cy, ax1, axy, ay1 ...] https://docs.google.com/spreadsheets/d/1O5jA-vvXOskK_HPwXfzVqKkuItNKC6EtoWIE5DpuBzs/edit#gid=0 
    public float enemySpeed = 1.0f; //a factor which is multiplied by the speed of each enemy to slow all enemys down or speed them up
    public float enemyAttackSpeed = 1.0f; //a factor to speed player attacks up or slow them down
    public float crit = 0f; //The amount of damage the player deals in addition to "playerDamage" when executing a critical attack
    public float attackDuration = 1.0f; //The duration of the Attack animation
    public float healthGainFactor = 1.0f; //The factor used to calculate the amount of health you gain through items
    public float thorns = 0.0f; //the percentage of damage the enemy gets while trying to attack the player
    public float lifeSteal = 0.0f; //the percentage of health the player gets from the enemy during combat
    public float regen = 0f; //the amount of regeneration the player gets

    //bools indicating that the corresponding skills were skilled:
    public bool enemyFreeze = false;
    public bool firstStrike = true;
    public bool combo = false;
    public bool shock = false;
    public bool lifeSaver = false; //Life Saver gives you a health boost when your health is close to 0. 
    public bool dash = false;
    public bool shield = false;

    //Related to shield skill:
    public float armor = 0.0f; //Percentage of damage protection
    public float shieldDurability;
    public float maxShieldDurability;
    public float shieldAbsorption; //Percentage how much damage the shield absorbs. The absorbed amount is subtracted from shieldDurability. The remaining amount is subtracted from health
    public float shieldRegen; //the amount of durability the shiled gains every second

    //Related to Dash skill:
    public bool dashing; //Is true as long as the player is dashing. Disables collisions with enemys in that period

    public int CurrLvl = 1; //displays your current level in natural numbers
    public int xpLevel = 5; //Is not supposed to be in use anymore but a script is accessing it

    //References:
    private LevelSwitcher doorScript; //Reference to the door script which opens the door to the next level when the scene is cleared
    public GameObject loadingScreen; //Reference to the loading screen to activate it during scene transitions
    //public GameObject skilltree; //Reference to the skilltree. Is not used anymore
    

    // Awake is called before Start
    void Awake()
    {
        DontDestroyOnLoad(this); //Tells the DataManager Object to keep existing after scene switches
    }

    // Start is called before the first frame update
    void Start() //Handles the random generation of the scene array
    {
        sceneOrder = new int[levelsUntilBossfight + 2];
        sceneOrder[0] = 1; //Set the Main Menu as the first scene.
        for (int i = 1; i <= (levelsUntilBossfight); i++) //generate random room sequence
        {
            sceneOrder[i] = Random.Range(3, SceneManager.sceneCountInBuildSettings);
        }
        sceneOrder[levelsUntilBossfight + 1] = bossLevelSceneIndex; //Adds the boss level as the last level
    }
    public void LoadReferences(GameObject obj) //Gets called every time the door is loaded into the scene to get a reference to the door present in the scene
    {
        doorScript = obj.GetComponent<LevelSwitcher>();

        if (loadingScreen != null) //A bug is causing the loadingScreen to stay activated sometimes. This is preventig that bug
            loadingScreen.SetActive(false);
    }
    public void Update()// Update is called once per frame
    {
        if(GameObject.FindWithTag("Enemy") == null && currentArrayIndex > 0 && doorScript != null) //Opens the door to then next scene, wehn scene is cleared
        {
           doorScript.OpenDoor();
        }

        health += (float)(regen * Time.deltaTime); //increases the players health every frame if regenereation is skilled
        shieldDurability += shieldRegen * Time.deltaTime; //increases the shields durability every frame

        /*
        if (Input.GetKeyDown("n")) //for debug purposes. Switches to the next scene when n is pressed
            NextScene();
        */
    }


    /* Pseudo Code for a checkpoint system which we didn't implement
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
     *}
     * 
     */

    public void PauseGame(bool pauseRequested) //PauseGame(true) pauses the game. PauseGame(false) unpauses the game
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
    *public void NextScene()
    *{
    *    nextScene = sceneOrder[currentArrayIndex + 1];
    *    SceneManager.LoadScene(nextScene);
    *    currentArrayIndex++;
    *    currentScene = SceneManager.GetActiveScene().buildIndex;
    *}
    */

    // - - - - - - - - - - - - - - CODE BELOW THIS LINE IS STILL WORK IN PROGRESS - - - - - - - - - - - - - - -

    public void NextScene()
    {
        //Checkpoint(); //Not imlemented

        shieldDurability = maxShieldDurability; //resets the durability of the shield

        if (loadingScreen != null) //Shows the Loading screen if a reference is set
        {
            loadingScreen.SetActive(true);
        }

        nextScene = sceneOrder[currentArrayIndex + 1]; //pulls next scene from randomized array index
        currentArrayIndex++; 
        //currentScene = SceneManager.GetActiveScene().buildIndex; //gets current scene build index 
        StartCoroutine(LoadLevelAsync()); //start async loading. Enables the scene to be loaded in the background

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
