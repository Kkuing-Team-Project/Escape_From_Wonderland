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
    public Button uiButton; // UI 버튼을 참조할 변수

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());

        // UI 버튼 할당
        uiButton = GameObject.Find("btn_Start").GetComponent<Button>();
        uiButton.interactable = false; // 처음에 비활성화
        // uiButton.color = new Color(1f, 1f, 1f, 0f);
    }

    IEnumerator NormalChat(string narrator, string narration, int charactor)
    {
        int a = 0;
        Name.text = narrator;
        writerText = "";

        if (charactor == 1)
        {
            emptyImage.sprite = changeSprite;

            // UI 버튼 활성화
            uiButton.interactable = true;
        }

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("플레이어", "나는 플레이어다", 0));
        yield return StartCoroutine(NormalChat("앨리스", "나는 앨리스다", 1));
    }

    // UI 버튼 클릭 이벤트 처리
    public void OnButtonClick()
    {
        StartCoroutine(NormalChat("다른 캐릭터", "다른 대화 내용", 2));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
