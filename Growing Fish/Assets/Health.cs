using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private Image red;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        red = GameObject.Find("Red").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        red.fillAmount = (float)playerInfo.health / playerInfo.maxHealth;
    }
}
