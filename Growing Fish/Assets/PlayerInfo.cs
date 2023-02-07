using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float pointsMultiplier;
    public float damageMultiplier;
    public float timeMultiplier;
    public float growMultiplier;
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

    public void IncreaseSize(float amount)
    {
        gameObject.transform.localScale *= (amount * growMultiplier / size) + 1;
        size = playerSprite.bounds.size.x;
    }
}
