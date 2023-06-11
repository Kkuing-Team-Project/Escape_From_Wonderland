using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rabbit : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(-3, rigid.velocity.y);
    }
}
