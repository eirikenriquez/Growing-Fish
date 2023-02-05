using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownPrefab : MonoBehaviour
{
    public GameObject prefab;
    public GameObject boxColliderObject;

    public int numberOfBombs = 5;
    //public float spawnRadius = 5f;


    void Start()
    {
        if (boxColliderObject == null)
        {
            Debug.LogError("boxColliderObject is not assigned");
            return;
        }
        BoxCollider2D boxCollider = boxColliderObject.GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("boxColliderObject does not have a BoxCollider2D component");
            return;
        }
        Bounds bounds = boxCollider.bounds;
        for (int i = 0; i < numberOfBombs; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
                Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y),
                0
            );
            randomPosition.x += Random.Range(-0.5f, 0.5f);
            randomPosition.y += Random.Range(-0.5f, 0.5f);
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }

}