using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LoopingBG : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float parallaxFactor = 0.1f;
    private float offset;
    private Material mat;
    private float backgroundWidth;
    private float leftBound;
    private float rightBound;

    public GameObject Player;
    public GameObject Camera;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        backgroundWidth = GetComponent<Renderer>().bounds.size.x;
        leftBound = backgroundWidth / 2;
        rightBound = -leftBound;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed);
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        // Constrain the character's movement
        Vector3 playerPosition = Player.transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, rightBound, leftBound);
        Player.transform.position = playerPosition;

        // Move the camera based on the player's position and the parallax factor
        Vector3 cameraPosition = Camera.transform.position;
        cameraPosition.x = Mathf.Clamp(playerPosition.x * parallaxFactor, rightBound, leftBound);
        Camera.transform.position = cameraPosition;
    }
}




