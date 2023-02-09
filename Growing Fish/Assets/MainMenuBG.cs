using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBG : MonoBehaviour
{
    public float bgSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePositionX = new Vector2(Input.mousePosition.x, 0);
        Debug.Log(mousePositionX);
        gameObject.transform.position = Vector2.MoveTowards(transform.position, mousePositionX, Vector2.Distance(mousePositionX, transform.position) * bgSpeed * Time.deltaTime);
    }
}
