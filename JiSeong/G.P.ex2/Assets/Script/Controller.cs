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
    public Sprite changeSprite2;
    public Sprite changeSprite3;
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

        if (charactor == 2)
        {
            emptyImage.sprite = changeSprite2;

            // UI 버튼 활성화
            uiButton.interactable = true;
        }

        if (charactor == 3)
        {
            emptyImage.sprite = changeSprite3;

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
        yield return StartCoroutine(NormalChat("앨리스", "어머, 뭘 그렇게 급하게 찾고 있는 거야?", 1));
        yield return StartCoroutine(NormalChat("주인공", "앨리스, 들어줘. 이 열쇠가 이상한 나라에서 탈출하기 위한 열쇠라고 하더라고.", 3));
        yield return StartCoroutine(NormalChat("앨리스", "탈출? 꼭 탈출 해야겠어? 여긴 환상적인 세계라고!\n여기서 즐거운 시간을 보내면 되는거 아니야?", 1));
        yield return StartCoroutine(NormalChat("주인공", "앨리스, 이상한 나라에서 무슨 일이 벌어지고 있는지 모르니?\n여기서 탈출하지 않으면 영원히 갇혀 있을 거야.", 3));
        yield return StartCoroutine(NormalChat("앨리스", "그럴 리 없어. 원더랜드는 우리의 행복과 자유의 공간일 뿐이야. 탈출할 필요 없어!", 1));
        yield return StartCoroutine(NormalChat("주인공", "앨리스....미안, 하지만 난 이곳을 탈출해야겠어.", 3));
        yield return StartCoroutine(NormalChat("앨리스", "그렇다면 너를 죽여버리겠어.....", 1));
        yield return StartCoroutine(NormalChat("앨리스", "사실 나도 여기가 끔찍하고 악몽 같단 말이야! 당장 그 열쇠 내놔!", 2));

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
