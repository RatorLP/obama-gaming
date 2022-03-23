using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{
    public bool pauseRequested;
    GameObject pauseMenu;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseRequested = true;
            pauseMenu.SetActive(true);
        }
    }

    void Resume ()
    {
        pauseRequested = false;
        pauseMenu.SetActive(false);
    }



    public void QuitGame() //quits game. to be used by quit button only.
    {
        Debug.Log("used quit button");
        Application.Quit();
    }
}
