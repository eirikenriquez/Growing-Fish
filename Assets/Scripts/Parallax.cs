using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float parallaxFactor = 0.1f;
    private float offset;
    private Material mat;
    private float backgroundWidth;
    private float leftBound;
    private float rightBound;

    //public GameObject Player;
    //public GameObject Camera;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        backgroundWidth = GetComponent<Renderer>().bounds.size.x;
        leftBound = backgroundWidth / 2;
        rightBound = -leftBound;
    }

    /*void Update()
    {
        offset += (Time.deltaTime * scrollSpeed);
        //mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

    }*/

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed);
        if (offset > leftBound)
        {
            offset = rightBound;
        }
        //mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

}
