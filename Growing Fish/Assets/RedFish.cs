using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFish : Fish
{
    private Animator anim;

    // Start is called before the first frame update
    new void Start()
    {
        redFish = true;
        fishSpawn = GameObject.Find("RedFishSpawn").GetComponent<FishSpawn>();
        base.Start();
        anim = GetComponent<Animator>();
    }

    new void Update()
    {
        base.Update();
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        anim.SetBool("isMoving", moving);
    }

}