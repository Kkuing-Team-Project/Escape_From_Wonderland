using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform 컴포넌트

    private RectTransform uiRectTransform; // UI 오브젝트의 RectTransform 컴포넌트

    private void Start()
    {
        uiRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // 플레이어의 월드 좌표를 UI 캔버스 좌표로 변환
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(playerTransform.position);

        // UI 오브젝트의 위치를 플레이어의 위치로 설정
        uiRectTransform.position = playerScreenPos;
    }
}
