using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIManager : MonoBehaviour
{
    public GameObject[] Canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Canvas[0].SetActive(true);
            Canvas[1].SetActive(false);
        }
    }
}
