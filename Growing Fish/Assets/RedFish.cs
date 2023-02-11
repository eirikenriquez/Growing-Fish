using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFish : Fish
{
    // Start is called before the first frame update
    new void Start()
    {
        redFish = true;
        fishSpawn = GameObject.Find("RedFishSpawn").GetComponent<FishSpawn>();
        base.Start();
    }

}