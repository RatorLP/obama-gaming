using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  
 *  Rico Rotar 
 *  Main Menu script for obamagaming dungeon crawler game project
 *  
 *  2022
 *  last rev.: 26-JAN-2022-16-28-00
 */

public class MainMenu : MonoBehaviour
{
    public void PlayGame() //loads the next available Scene (buildIndex + 1). To be used for main menu play button only. 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu() //goes back to the main menu without saving. for internal testing only.
    {
        SceneManager.LoadScene("menu"); 
    }

    public void QuitGame() //quits game, to be used on UI quit button
    {
        Debug.Log("used quit button");
        Application.Quit();
    }
}
