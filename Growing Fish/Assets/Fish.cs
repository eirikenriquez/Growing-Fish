using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    // Fish properties
    public Boolean facingRight;
    public float Size { get; private set; }
    public SpriteRenderer sprite;
    public FishSpawn fishSpawn;
    public GameObject player;
    public float maxDistanceToAct;
    public float speed;
    private Vector2 currentDirection;
    private Vector2 currentPosition;
    private Vector2 lastPosition;

    // Start is called before the first frame update
    protected void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Size = sprite.bounds.size.x;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= maxDistanceToAct)
        {
            ChaseOrRun();
        }
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;

        if (currentPosition != lastPosition)
        {
            UpdateDirection();
            FlipSprite();
        }

        lastPosition = currentPosition;
    }

    private void UpdateDirection()
    {
        currentDirection = (currentPosition - lastPosition).normalized;
    }

    public void FlipSprite()
    {
        if ((currentDirection.x < 0 && facingRight) || (currentDirection.x > 0 && !facingRight))
        {
            gameObject.transform.Rotate(new Vector2(0, 180));
            facingRight = !facingRight;
        }
    }

    public void Eaten()
    {
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
