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
    public GameObject fish;
    public BoxCollider2D background;
    public PlayerInfo playerInfo;
    private List<float> existingSizes;
    private List<GameObject> existingFish;

    // Start is called before the first frame update
    void Start()
    {
        existingSizes = new List<float>();
        existingFish = new List<GameObject>();
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
        while (Vector2.Distance(FishPosition, playerInfo.transform.localPosition) < minDistance);

        do
        {
            GenerateSize();
        }
        while (existingSizes.Contains(fish.transform.localScale.x)) ;

        existingSizes.Add(fish.transform.localScale.x);

        GameObject fishInstance = Instantiate(fish, FishPosition, Quaternion.identity);
        existingFish.Add(fishInstance);

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
        Vector2 scaleVector = new Vector3(size, size);
        fish.transform.localScale = scaleVector;
    }

    // Checks if fish is in boundary and removes them if not in bounds
    private void ResetFishPosition()
    {
        for (int i = 0; i < existingFish.Count; i++)
        {
            if (!spawnBoundaries.Contains(existingFish[i].GetComponent<Fish>().CurrentPosition))
            {
                Debug.Log("ResetFishPosition");
                RemoveFish(existingFish[i]);
                i--;
            }
        }
    }

    public void RemoveFish(GameObject toRemove)
    {
        Debug.Log("RemoveFish");

        Destroy(toRemove);
        existingSizes.Remove(toRemove.transform.localScale.x);
        existingFish.Remove(toRemove);
        fishCount--;
    }
}

