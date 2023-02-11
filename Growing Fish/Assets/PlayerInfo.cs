using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public const int POINTS_TIMES_10 = 10; // needed for point multiplier
    public float pointsMultiplier;
    public float damageMultiplier;
    public float healthIncreaseMultiplier;
    public int timePointsPerInterval;
    public float timeInterval;
    public float growMultiplier;
    public int maxHealth;
    public int health;
    public static int score;
    public float size;
    public float maxSize;
    public SpriteRenderer playerSprite;


    // Start is called before the first frame update
    void Start()
    {
        size = playerSprite.bounds.size.x;
        score = 0;
        health = maxHealth;
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
        return (int)(points * pointsMultiplier) * POINTS_TIMES_10;
    }

    public void TakeDamage(float damage)
    {
        if (health - CalculateDamageTaken(damage) <= 0)
        {
            health = 0;
            GetComponent<PlayerDeath>().Dead();
        }
        else
        {
            health -= CalculateDamageTaken(damage);
            //using coroutine to change color when shark is hit.
            StartCoroutine(FlashRed());
        }
    }

    public int CalculateDamageTaken(float damage)
    {
        return (int)(damage * damageMultiplier);
    }

    //method for changing color.
    IEnumerator FlashRed()
    {
        Color originalColor = playerSprite.color;
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = originalColor;
    }

    public void IncreaseHealth(float size)
    {
        if (health + CalculateHealthIncrease(size) < maxHealth)
        {
            health += CalculateHealthIncrease(size);
        }
        else
        {
            health = maxHealth;
        }
    }

    private int CalculateHealthIncrease(float size)
    {
        return (int)(size * healthIncreaseMultiplier);
    }

    public void IncreaseSize(float amount)
    {
        if (CalculateSize(amount) <= maxSize) 
        {
            gameObject.transform.localScale *= CalculateSize(amount);
            size = playerSprite.bounds.size.x;
        }
        else
        {
            gameObject.transform.localScale = new Vector2(maxSize, maxSize);
            size = maxSize;
        }
    }

    private float CalculateSize(float amount)
    {
        return (amount * growMultiplier / size) + 1;
    }
}
