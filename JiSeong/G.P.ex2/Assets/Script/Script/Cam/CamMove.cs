using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private Transform spaceshipTransform;
    public Vector3 offset;

    private void Start()
    {
        spaceshipTransform = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (spaceshipTransform != null)
        {
            Vector3 desiredPosition = spaceshipTransform.position + offset;
            transform.position = desiredPosition;
        }
    }
}
