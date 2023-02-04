using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int score;
    public int hp;
    public float size;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        size = playerSprite.bounds.size.x;
        score = 0;
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(float points)
    {
        score += (int)(points * 100);
    }

    public void TakeDamage(float damage)
    {
        hp -= (int)(damage * 100);
    }
}
