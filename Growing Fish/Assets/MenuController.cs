using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator animator;
    
    public void Fade()
    {
        animator.SetTrigger("trigger");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void goToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
