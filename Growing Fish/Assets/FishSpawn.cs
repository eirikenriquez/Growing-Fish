using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public Vector2 FishPosition { get; private set; }
    public int minDistance;
    public int maxDistance;
    public float minFishSize;
    public float maxFishSize;
    public int FishCount { get; private set; }
    public int maxFishes;
    public GameObject tuna;
    public PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FishCount < maxFishes)
        {
            SpawnAFish();
        }
    }

    private void SpawnAFish()
    {
        do
        {
            GeneratePosition();
        } while (Vector2.Distance(FishPosition, playerInfo.transform.localPosition) < minDistance);

        Instantiate(tuna, FishPosition, Quaternion.identity);
        GenerateSize();
        FishCount++;
    }

    private void GeneratePosition()
    {
        int x = Random.Range(-maxDistance, maxDistance);
        int y = Random.Range(-maxDistance, maxDistance);

        FishPosition = new Vector2(x, y);
    }

    private void GenerateSize()
    {
        float size = Random.Range(minFishSize, maxFishSize);
        Vector3 scaleVector = new Vector3(size, size, size);
        tuna.transform.localScale = scaleVector;
    }
}
