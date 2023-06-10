using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_ESC : MonoBehaviour
{
    public GameObject Canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("True");
            Canvas.SetActive(true);
        }
    }
}