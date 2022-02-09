using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public float playerDamage = 40;
    public int health = 100;
    public int levelsUntilBossfight = 100;
    public int[] sceneOrder; 
    private int bossLevelSceneIndex = 0; // contains the Index of the scene for the bossfight
    private int currentArrayIndex = 0;
    public int nextScene;
    public int currentScene;
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
        for(int i=1; i <= (levelsUntilBossfight); i++) //generate random room sequence
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

    public void NextScene()
    {
        loadingScreen.SetActive(true);

        nextScene = sceneOrder[currentArrayIndex + 1];
        currentArrayIndex++;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
