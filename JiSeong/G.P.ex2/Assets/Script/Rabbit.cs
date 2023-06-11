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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Rabbit과 Player가 충돌한 경우 처리할 내용을 작성합니다.
            Debug.Log("Rabbit과 Player가 충돌했습니다!");
        }
    }
}
