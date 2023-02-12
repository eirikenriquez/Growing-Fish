using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Fish
{
    // Start is called before the first frame update
    new void Start()
    {
        fishSpawn = GameObject.Find("JellyFishSpawn").GetComponent<FishSpawn>();
        base.Start();
    }

}
