using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
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
}
