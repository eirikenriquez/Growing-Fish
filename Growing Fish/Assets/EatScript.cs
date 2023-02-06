using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;
    public AudioSource eatSound;
    private FishSpawn fishSpawn;
    public float knockbackMultiplier; // used to calculate knockback damage

    // Start is called before the first frame update
    void Start()
    {
        fishSpawn = GameObject.Find("Fishes").GetComponent<FishSpawn>();
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
            Fish fishInstance = (Fish) collision.gameObject.GetComponent("Fish");

            if (CanEat(fishInstance))
            {
                Debug.Log("eat");
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
        Destroy(collision.gameObject);
        eatSound.Play();
        fishSpawn.fishCount--;
    }

    private void Hurt(Collision2D collision)
    {
        float xForce = -playerMovement.MoveDirection.x * knockbackMultiplier;
        float yForce = -playerMovement.MoveDirection.y * knockbackMultiplier;

        rb.AddForce(new Vector2(xForce, yForce));
    }
}
