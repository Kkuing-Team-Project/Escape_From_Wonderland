using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;

    public float rotationSpeed = 100f;

    private void Update()
    {
        RotateObject(objectA, rotationSpeed);
        RotateObject(objectB, -rotationSpeed);
    }

    private void RotateObject(GameObject obj, float speed)
    {
        obj.transform.RotateAround(objectC.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
