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
    public AudioSource hurtSound;
    public float knockbackMultiplier; // used to calculate knockback damage
    public TMPro.TextMeshProUGUI feedbackText; //for eating feedback
    public float feedbackDuration = 2f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // check if player collided with fish
        if (collision.gameObject.CompareTag("Fish"))
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
                Hurt(fishInstance, collision);
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
        playerInfo.fishEaten++;
        playerInfo.AddScore(fish.Size);
        eatSound.Play();
        fish.Eaten();
        Grow(fish.Size);
        //collision.gameObject.GetComponent<Fish>().Eaten();

        if (fish.redFish)
        {
            playerInfo.IncreaseHealth(fish.Size);
        }

        DisplayFeedback(fish, false);
    }

    // bool hurt - true if player takes damage, false if player earns points
    private void DisplayFeedback(Fish fish, bool hurt)
    {
        if (!hurt)
        {
            feedbackText.text = "+" + playerInfo.CalculateEarnedPoints(fish.Size);
            feedbackText.color = new Color(248, 193, 0);
        } 
        else
        {
            feedbackText.text = "-" + playerInfo.CalculateDamageTaken(fish.Size);
            feedbackText.color = Color.red;
        }

        feedbackText.enabled = true;
        feedbackText.transform.position = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(fish.CurrentPosition);
        Invoke("HideFeedbackText", feedbackDuration);
    }

    private void Grow(float amount)
    {
        playerInfo.IncreaseSize(amount);
    }

    private void Hurt(Fish fish, Collision2D collision)
    {
        // knockback
        float xForce = -playerMovement.MoveDirection.x * knockbackMultiplier;
        float yForce = -playerMovement.MoveDirection.y * knockbackMultiplier;
        rb.AddForce(new Vector2(xForce, yForce));

        // minus health
        playerInfo.TakeDamage(fish.Size);

        DisplayFeedback(fish, true);
        hurtSound.Play();
    }

    void HideFeedbackText()
    {
        feedbackText.enabled = false;
    }
}
