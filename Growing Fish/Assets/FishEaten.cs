using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishEaten : MonoBehaviour
{
    private TMP_Text fishEatenText;
    private PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        fishEatenText.text = string.Format("{0:000000}", playerInfo.fishEaten);
    }

    private void GetReferences()
    {
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        fishEatenText = GetComponent<TMP_Text>();
    }
}
