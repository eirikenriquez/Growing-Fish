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
            gameObject.transform.position = Vector2.MoveTowards(transform.position, randomPosition, speed*Time.deltaTime);
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

    private void CheckPosition()
    {
        CurrentPosition = transform.position;

        if (CurrentPosition != lastPosition)
        {
            UpdateDirection();
            FlipSprite();
            moving = true;
        }
        else
        {
            moving = false;
        }

        lastPosition = CurrentPosition;
    }

    private void UpdateDirection()
    {
        currentDirection = (CurrentPosition - lastPosition).normalized;
    }

    public void FlipSprite()
    {
        if ((currentDirection.x < 0 && facingRight) || (currentDirection.x > 0 && !facingRight))
        {
            gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            facingRight = !facingRight;
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
