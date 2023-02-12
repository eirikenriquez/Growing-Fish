using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float fallSpeed;
    public float timeToWait;
    public bool dead;

    private void Start()
    {
        dead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            GetComponent<PlayerInfo>().health = 0;
            Dead();
        }
    }

    public void Dead()
    {
        dead = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<Animator>().SetBool("dead", dead);
        StartCoroutine(SinkToGround());
    }

    private IEnumerator SinkToGround()
    {
        GetComponent<Rigidbody2D>().gravityScale = fallSpeed;
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("Dead Scene");
    }
}
