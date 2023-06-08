using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hat : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void OnTriggerEnter2D(Collider2D H)
    {
        if (H.gameObject.CompareTag("Player"))
        {
            print("¸ðÀÚ");
            Destroy(gameObject);
        }
    }
}
