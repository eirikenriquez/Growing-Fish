using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public Bounds spawnBoundaries;
    public Vector2 FishPosition { get; private set; }
    public int minDistance;
    //public int maxDistance;
    public float minFishSize;
    public float maxFishSize;
    public int fishCount;
    public int maxFishes;
    public GameObject tuna;
    public BoxCollider2D background;
    public PlayerInfo playerInfo;
    private List<Vector2> existingPositions;
    private List<float> existingSizes;
    private List<GameObject> existingTuna;

    // Start is called before the first frame update
    void Start()
    {
        existingPositions = new List<Vector2>();
        existingSizes = new List<float>();
        existingTuna = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSpawnBoundaries();

        if (fishCount < maxFishes)
        {
            SpawnAFish();
        }

        ResetFishPosition();
    }

    private void CalculateSpawnBoundaries()
    {
        spawnBoundaries = background.bounds;
    }

    private void SpawnAFish()
    {
        do
        {
            GeneratePosition();
        }
        while (existingPositions.Contains(FishPosition) || Vector2.Distance(FishPosition, playerInfo.transform.localPosition) < minDistance);

        do
        {
            GenerateSize();
        }
        while (existingSizes.Contains(tuna.transform.localScale.x)) ;

        existingPositions.Add(FishPosition);
        existingSizes.Add(tuna.transform.localScale.x);

        GameObject tunaInstance = Instantiate(tuna, FishPosition, Quaternion.identity);
        existingTuna.Add(tunaInstance);

        fishCount++;
    }

    private void GeneratePosition()
    {
        float x = Random.Range(spawnBoundaries.min.x, spawnBoundaries.max.x);
        float y = Random.Range(spawnBoundaries.min.y, spawnBoundaries.max.y);

        FishPosition = new Vector2(x, y);
    }

    private void GenerateSize()
    {
        float size = Random.Range(minFishSize, maxFishSize);
        Vector3 scaleVector = new Vector3(size, size, size);
        tuna.transform.localScale = scaleVector;
    }

    // Checks if fish is in boundary and removes them if not in bounds
    private void ResetFishPosition()
    {
        for (int i = 0; i < existingTuna.Count; i++)
        {
            if (!spawnBoundaries.Contains(existingTuna[i].transform.position))
            {
                RemoveFish(existingTuna[i]);
                i--;
            }
        }
    }

    public void RemoveFish(GameObject toRemove)
    {
        Destroy(toRemove);
        existingPositions.Remove(toRemove.transform.position);
        existingSizes.Remove(toRemove.transform.localScale.x);
        existingTuna.Remove(toRemove);
        fishCount--;
    }
}

