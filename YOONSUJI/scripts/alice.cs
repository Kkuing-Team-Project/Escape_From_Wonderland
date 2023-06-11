using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "move") //move가 플레이어임 각자 씬에 맞춰서 수정
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroy");
        }
    }

}
