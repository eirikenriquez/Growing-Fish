using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadSceneScript : MonoBehaviour
{
    public float timeToDisplayScreen;
    public TMP_Text timerText;
    private int countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = (int)timeToDisplayScreen;
        StartCoroutine(ShowScreenForABitThenGoBackToMainMenu());
    }

    private IEnumerator ShowScreenForABitThenGoBackToMainMenu()
    {
        while (countdown > 0)
        {
            timerText.SetText("Going back to main menu in " + countdown);
            yield return new WaitForSeconds(1);
            countdown--;
        }

        // load main menu scene
        SceneManager.LoadScene("Main Menu");
    }
}
