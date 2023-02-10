using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public const int POINTSTIMESTEN = 10; // needed for point multiplier
    public float pointsMultiplier;
    public float damageMultiplier;
    public int timePointsPerInterval;
    public float timeInterval;
    public float growMultiplier;
    public int health;
    public static int score;
    public float size;
    public SpriteRenderer playerSprite;


    // Start is called before the first frame update
    void Start()
    {
        size = playerSprite.bounds.size.x;
        score = 0;
        health = 100;
        StartCoroutine(AutoIncreaseScore());
    }

    IEnumerator AutoIncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            score += timePointsPerInterval;
        }
    }

    public void AddScore(float points)
    {
        score += CalculateEarnedPoints(points);
    }

    public int CalculateEarnedPoints(float points)
    {
        return (int)(points * pointsMultiplier) * POINTSTIMESTEN;
    }

    public void TakeDamage(float damage)
    {
        if (health - (int)(damage * damageMultiplier) <= 0) 
        {
            GetComponent<PlayerDeath>().GoToDeadScreen();
        }
        else
        {
            health -= (int)(damage * damageMultiplier);
            //using coroutine to change color when shark is hit.
            StartCoroutine(FlashRed());
        }
    }
    //method for changing color.
    IEnumerator FlashRed()
    {
        Color originalColor = playerSprite.color;
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = originalColor;
    }

    public void IncreaseSize(float amount)
    {
        gameObject.transform.localScale *= (amount * growMultiplier / size) + 1;
        size = playerSprite.bounds.size.x;
    }
}
