using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Obamagaming dungeon crawler project
 * Main Menu control script 
 * 
 * Rico Rotar
 * latest revision: 27-JAN-2022-12-32-00
 */


public class MainMenu : MonoBehaviour
{
    public void PlayGame() //jumps to the next scene (buildIndex + 1). for main menu play button, might be changed in the future
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu() //goes back to the main menu without saving progress. for debug & testing use only.
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame() //quits game. to be used by quit button only.
    {
        Debug.Log("used quit button");
        Application.Quit();
    }
}
