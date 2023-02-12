using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToHelpScene()
    {
        SceneManager.LoadScene("Help Scene");
    }
}
