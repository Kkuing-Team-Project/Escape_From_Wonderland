using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rabbit : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-3, rb.velocity.y);
    }
}