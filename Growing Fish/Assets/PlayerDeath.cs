using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            GoToDeadScreen();
        }
    }

    public void GoToDeadScreen()
    {
        SceneManager.LoadScene("Dead Scene");
    }
}
