using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Debug.Log("ayo es funktioniert");
        Application.Quit();
    }
}
