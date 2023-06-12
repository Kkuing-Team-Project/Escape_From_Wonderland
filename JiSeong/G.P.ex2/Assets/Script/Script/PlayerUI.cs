using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 위치를 가리키는 Transform 변수
    public RectTransform speechBubbleRectTransform; // 말풍선의 RectTransform 변수
    public float speechBubbleStartX; // 말풍선의 시작 X 좌표
    public float speechBubbleEndX; // 말풍선의 끝 X 좌표
    public float playerStartX; // 플레이어의 시작 X 좌표
    public float playerEndX; // 플레이어의 끝 X 좌표
    public float playerMoveSpeed; // 플레이어 이동 속도

    private void Update()
    {
        // 플레이어의 X 좌표를 정규화하여 speechBubble의 이동 대상 X 좌표를 계산
        float normalizedPlayerX = Mathf.InverseLerp(playerStartX, playerEndX, playerTransform.position.x);

        // speechBubble의 X 좌표를 플레이어의 X 좌표에 맞게 보간하여 목표 X 좌표를 계산
        float targetSpeechBubbleX = Mathf.Lerp(speechBubbleStartX, speechBubbleEndX, normalizedPlayerX);

        // 현재 speechBubble의 X 좌표와 목표 X 좌표 사이를 플레이어의 이동 속도로 보간하여 새로운 X 좌표를 계산
        float currentSpeechBubbleX = speechBubbleRectTransform.anchoredPosition.x;
        float newSpeechBubbleX = Mathf.MoveTowards(currentSpeechBubbleX, targetSpeechBubbleX, playerMoveSpeed * Time.deltaTime);

        // speechBubble의 위치를 새로운 X 좌표로 업데이트
        Vector2 newSpeechBubblePosition = new Vector2(newSpeechBubbleX, speechBubbleRectTransform.anchoredPosition.y);
        speechBubbleRectTransform.anchoredPosition = newSpeechBubblePosition;
    }
}

