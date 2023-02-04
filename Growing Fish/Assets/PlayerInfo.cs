using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float size;
    public float score;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        size = playerSprite.bounds.size.x;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
