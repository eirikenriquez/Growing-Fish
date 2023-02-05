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
    private List<Vector2> existingPositions;
    private List<float> existingSizes;

    // Start is called before the first frame update
    void Start()
    {
        existingPositions = new List<Vector2>();
        existingSizes = new List<float>();
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
        GeneratePosition();

        while (existingPositions.Contains(FishPosition) || Vector2.Distance(FishPosition, playerInfo.transform.localPosition) < minDistance)
        {
            GeneratePosition();
        }

        GenerateSize();

        while (existingSizes.Contains(tuna.transform.localScale.x))
        {
            GenerateSize();
        }

        existingPositions.Add(FishPosition);
        existingSizes.Add(tuna.transform.localScale.x);

        Instantiate(tuna, FishPosition, Quaternion.identity);
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

