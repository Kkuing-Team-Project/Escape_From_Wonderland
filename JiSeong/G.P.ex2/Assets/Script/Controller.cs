using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    public Text ChatText;
    public Text Name;
    public string writerText = "";
    public Image emptyImage;
    public Sprite changeSprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    IEnumerator NormalChat(string narrator, string narration, int charactor)
    {
        int a = 0;
        Name.text = narrator;
        writerText = "";

        if(charactor == 1)
        {
            emptyImage.sprite = changeSprite;
        }

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                break;
            }
            yield return null;
        }
    }


    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("플레이어","나는 플레이어다", 0));
        yield return StartCoroutine(NormalChat("앨리스","나는 앨리스다", 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
