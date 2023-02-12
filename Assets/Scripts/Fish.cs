using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    // Fish properties
    public bool redFish;
    public bool facingRight;
    public bool moving;
    public float Size { get; private set; }
    public SpriteRenderer sprite;
    public FishSpawn fishSpawn;
    public GameObject player;
    public float maxDistanceToAct;
    public float speed;
    private Vector2 currentDirection;
    public Vector2 CurrentPosition { get; private set; }
    public Vector2 lastPosition;
    public Vector2 randomPosition;
    private float flipDelay = 0.5f; // The delay between each sprite flip in seconds
    private float lastFlipTime = 0f; // The time of the last sprite flip
    //private float flipWaitTime = 0.5f;
    //private float currentWaitTime = 0.0f;
    private bool canFlip = true;
    private float flipTimer = 0f;


    // Start is called before the first frame update
    protected void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Size = sprite.bounds.size.x;
        player = GameObject.Find("Player");
        GenerateRandomPosition();
    }

    // Update is called once per frame
    protected void Update()
    {
        CheckPosition();
        CheckDistanceFromPlayer();
        CheckPosition();

        // Only flip the sprite if enough time has passed since the last flip
        if (Time.time - lastFlipTime >= flipDelay)
        {
            FlipSprite();
            lastFlipTime = Time.time;
        }
    }

    private void CheckDistanceFromPlayer()
    {
        if (DistanceFromPlayer() <= maxDistanceToAct)
        {
            ChaseOrRun();
        }
        else
        {
            MoveRandomly();
        }
    }

    private float DistanceFromPlayer()
    {
        return Vector2.Distance(gameObject.transform.position, player.transform.position);
    }

    private void MoveRandomly()
    {
        if (CurrentPosition != randomPosition)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
        }
        else
        {
            GenerateRandomPosition();
        }
    }

    private void GenerateRandomPosition()
    {
        float randomX = Random.Range(-(gameObject.transform.position.x * 2), gameObject.transform.position.x * 2);
        float randomY = Random.Range(-(gameObject.transform.position.y * 2), gameObject.transform.position.y * 2);
        randomPosition = new Vector2(randomX, randomY);
    }

    private IEnumerator WaitBeforeFlipping()
    {
        canFlip = false;
        yield return new WaitForSeconds(0.5f);
        canFlip = true;
    }

    private void CheckPosition()
    {
        CurrentPosition = transform.position;

        if (CurrentPosition != lastPosition)
        {
            
            UpdateDirection();
            moving = true;
        }
        else
        {
            moving = false;
        }

        // Only flip the sprite if the fish is actually moving
        if (moving)
        {
            flipTimer += Time.deltaTime;
            if (flipTimer >= flipDelay)
            {
                FlipSprite();
                flipTimer = 0f;
            }
        }
        else
        {
            flipTimer = 0f;
        }

        lastPosition = CurrentPosition;
    }


    private void UpdateDirection()
    {
        currentDirection = (CurrentPosition - lastPosition).normalized;
    }

 


    private void FlipSprite()
    {
        // Only flip the sprite if the direction of movement has changed
        if ((currentDirection.x < 0 && facingRight) || (currentDirection.x > 0 && !facingRight))
        {
            gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            facingRight = !facingRight;
            StartCoroutine(WaitBeforeFlipping());
        }
    }

    public void Eaten()
    {
        Debug.Log("Eaten");
        fishSpawn.RemoveFish(gameObject);
    }

    public void ChaseOrRun()
    {
        if (player.GetComponent<PlayerInfo>().size <= this.Size)
        {
            Chase();
        }
        else
        {
            RunAway();
        }
    }

    private void Chase()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void RunAway()
    {
        gameObject.transform.Translate((transform.position - player.transform.position) * speed * Time.deltaTime);
    }
}
