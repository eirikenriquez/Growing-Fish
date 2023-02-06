using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownPrefab : MonoBehaviour
{
    public GameObject prefab;
    public GameObject boxColliderObject;
    private BoxCollider2D boxCollider;
    private Bounds bounds;
    public int numberOfBombs;
    public int maxBombs;
    private List<GameObject> existingBombs = new List<GameObject>();
    //public float spawnRadius = 5f;


    void Start()
    {
        if (boxColliderObject == null)
        {
            Debug.LogError("boxColliderObject is not assigned");
            return;
        }
        boxCollider = boxColliderObject.GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("boxColliderObject does not have a BoxCollider2D component");
            return;
        }
    }

    private void Update()
    {
        bounds = boxCollider.bounds;

        while (numberOfBombs < maxBombs)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
                Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y),
                0
            );
            randomPosition.x += Random.Range(-0.5f, 0.5f);
            randomPosition.y += Random.Range(-0.5f, 0.5f);
            GameObject instantiatedBomb = Instantiate(prefab, randomPosition, Quaternion.identity);
            existingBombs.Add(instantiatedBomb);
            numberOfBombs++;
        }

        ResetPosition();
    }

    private void ResetPosition()
    {
        for (int i = 0; i < existingBombs.Count; i++)
        {
            if (!bounds.Contains(existingBombs[i].transform.position))
            {
                Destroy(existingBombs[i]);
                existingBombs.Remove(existingBombs[i]);
                numberOfBombs--;
                i--;
            }
        }
    }
}