using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFollow : MonoBehaviour
{
    public Transform planet;
    public float speed = 8f;

    private void FixedUpdate()
    {
       Vector3 direction = planet.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }
}
