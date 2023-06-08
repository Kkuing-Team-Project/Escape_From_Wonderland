using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeItem : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D t)
    {
        if (t.gameObject.CompareTag("Player"))
        {   
            print("½Ã°è");
            Destroy(gameObject);
        }
    }
}