using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBG : MonoBehaviour
{
    private bool sharkFacingRight;
    public float sharkAmp;
    public float sharkBobFreq;
    public float bgSpeed;
    private Vector2 mousePositionX;
    private Camera dummyCamera; // for finding mouse location
    private Camera mainCamera;
    private GameObject cameraObject;
    private GameObject shark;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        FindMousePositionX();
        MoveCamera();
        FlipSharkSprite();
        MoveShark();
    }

    private void MoveShark()
    {
        // horizontally
        shark.transform.position = new Vector3(cameraObject.transform.position.x, shark.transform.position.y, 1);

        // vertically
        shark.transform.position = new Vector3(shark.transform.position.x, MathF.Sin(Time.time * sharkBobFreq) * sharkAmp + shark.transform.position.y, 1);
    }

    private void FlipSharkSprite()
    {
        // need to minus the camera x value as the camera position is always moving...
        if ((mousePositionX.x - cameraObject.transform.position.x > 0 && !sharkFacingRight) || 
            (mousePositionX.x - cameraObject.transform.position.x < 0 && sharkFacingRight))
        {
            shark.transform.Rotate(new Vector2(0, 180));
            sharkFacingRight = !sharkFacingRight;
        }
    }

    private void GetReferences()
    {
        cameraObject = GameObject.Find("Main Camera");
        mainCamera = cameraObject.GetComponent<Camera>();
        shark = GameObject.Find("Main Menu Shark");
    }

    private void MoveCamera()
    {
        cameraObject.transform.position = Vector2.MoveTowards(cameraObject.transform.position, mousePositionX, Vector2.Distance(mousePositionX, cameraObject.transform.position) * bgSpeed * Time.deltaTime);
    }

    private void FindMousePositionX()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePositionX = new Vector2(mousePosition.x, 0);
    }
}
