using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;
    public Vector3 positionOffset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
       
        if (target != null)
        {
            Vector3 targetPosition = target.position + positionOffset;
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
