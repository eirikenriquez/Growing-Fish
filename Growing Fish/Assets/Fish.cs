using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Fish properties
    public float size { get; private set; }
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        size = spriteRenderer.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
