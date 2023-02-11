using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishEaten : MonoBehaviour
{
    private TMP_Text text;
    private PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("Fish Eaten: " + playerInfo.fishEaten);
    }

    private void GetReferences()
    {
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        text = GetComponent<TMP_Text>();
    }
}
