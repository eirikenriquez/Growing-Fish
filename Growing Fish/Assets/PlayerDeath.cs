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
            Dead();
        }
    }

    public void Dead()
    {
        StartCoroutine(SinkToGround());
        SceneManager.LoadScene("Dead Scene");
    }

    private IEnumerator SinkToGround()
    {
        GetComponent<Rigidbody2D>().gravityScale = fallSpeed;

        while (true)
        {    
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
