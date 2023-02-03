using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour
{
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // check if player collided with fish
        if (collision.gameObject.tag == "Fish")
        {
            SpriteRenderer fishSprite = (SpriteRenderer) collision.gameObject.GetComponent("SpriteRenderer");
            if (CanEat(fishSprite))
            {
                Debug.Log("eat");
                Eat(collision);
            } 
            else
            {
                Debug.Log("too big :(");
            }
        }
    }

    // true if fish is smaller than player
    // false otherwise
    private bool CanEat(SpriteRenderer eatenSprite)
    {
        return eatenSprite.bounds.size.x <= playerSprite.bounds.size.x;
    }

    private void Eat(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
