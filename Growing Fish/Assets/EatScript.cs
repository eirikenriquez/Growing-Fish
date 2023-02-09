using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatScript : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;
    public AudioSource eatSound;
    public float knockbackMultiplier; // used to calculate knockback damage
    public TMPro.TextMeshProUGUI feedbackText; //for eating feedback
    public float feedbackDuration = 2f;

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
            Fish fishInstance = (Fish)collision.gameObject.GetComponent("Fish");

            if (CanEat(fishInstance))
            {
                Debug.Log("eat");
                //get it's position
                Eat(fishInstance, collision);
            } 
            else
            {
                Debug.Log("too big :(");
                Hurt(collision);
                playerInfo.TakeDamage(fishInstance.Size);
            }
        }
    }

    // true if fish is smaller than player
    // false otherwise
    private bool CanEat(Fish fish)
    {
        return fish.Size <= playerInfo.size;
    }

    private void Eat(Fish fish, Collision2D collision)
    {
        playerInfo.AddPoints(fish.Size);
        eatSound.Play();
        fish.Eaten();
        Grow(fish.Size);
        //collision.gameObject.GetComponent<Fish>().Eaten();

        feedbackText.text = "+1";
        feedbackText.enabled = true;
        feedbackText.transform.position = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(fish.CurrentPosition);
        Invoke("HideFeedbackText", feedbackDuration);

    }



    private void Grow(float amount)
    {
        playerInfo.IncreaseSize(amount);
    }

    private void Hurt(Collision2D collision)
    {
        float xForce = -playerMovement.MoveDirection.x * knockbackMultiplier;
        float yForce = -playerMovement.MoveDirection.y * knockbackMultiplier;

        rb.AddForce(new Vector2(xForce, yForce));
    }

    void HideFeedbackText()
    {
        feedbackText.enabled = false;
    }
}
