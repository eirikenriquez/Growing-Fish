using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int pointsMultiplier;
    public int damageMultiplier;
    public int timeMultiplier;
    public int health;
    public float score;
    public float size;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        size = playerSprite.bounds.size.x;
        score = 0;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        AddTimePoints();
    }

    public void AddTimePoints()
    {
        score += Time.deltaTime * timeMultiplier;
    }

    public void AddPoints(float points)
    {
        score += points * pointsMultiplier;
    }

    public void TakeDamage(float damage)
    {
        health -= (int)(damage * damageMultiplier);
    }
}
