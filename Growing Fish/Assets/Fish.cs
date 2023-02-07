using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    // Fish properties
    public float Size { get; private set; }
    public FishSpawn fishSpawn;

    // Start is called before the first frame update
    protected void Start()
    {
        Size = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Eaten()
    {
        fishSpawn.RemoveFish(gameObject);
    }
}
