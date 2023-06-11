using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform ������Ʈ

    private RectTransform uiRectTransform; // UI ������Ʈ�� RectTransform ������Ʈ

    private void Start()
    {
        uiRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // �÷��̾��� ���� ��ǥ�� UI ĵ���� ��ǥ�� ��ȯ
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(playerTransform.position);

        // UI ������Ʈ�� ��ġ�� �÷��̾��� ��ġ�� ����
        uiRectTransform.position = playerScreenPos;
    }
}
