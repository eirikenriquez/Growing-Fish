using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : Fish
{
    // Start is called before the first frame update
    new void Start()
    {
        fishSpawn = GameObject.Find("TunaSpawn").GetComponent<FishSpawn>();
        base.Start();
    }

}
