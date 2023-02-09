using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TMP_Text scoreText;
    /*public int score = 0;
    public float timeInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
        StartCoroutine(AutoIncreaseScore());
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }*/

    private void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = string.Format("{0:000000}", PlayerInfo.score);
    }

    /*IEnumerator AutoIncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            AddScore(10);
        }
    }


    /*public TMP_Text scoreText;
    //public PlayerInfo playerInfo;
    //like subway surfers
    public int score = 0;
    public float timeInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
    }
  
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = string.Format("{0:000000}", score);
    }
    /*
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + (int)playerInfo.score;
    }*/
}
