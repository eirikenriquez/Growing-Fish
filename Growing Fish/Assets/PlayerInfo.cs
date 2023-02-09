using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float pointsMultiplier;
    public float damageMultiplier;
    public float timePointsPerInterval;
    public float timeInterval;
    public float growMultiplier;
    public int health;
    public static float score;
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
        score += points * pointsMultiplier;
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
        }
    }

    public void IncreaseSize(float amount)
    {
        gameObject.transform.localScale *= (amount * growMultiplier / size) + 1;
        size = playerSprite.bounds.size.x;
    }
}
