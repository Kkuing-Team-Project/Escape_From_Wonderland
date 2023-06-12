using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ�� ����Ű�� Transform ����
    public RectTransform speechBubbleRectTransform; // ��ǳ���� RectTransform ����
    public float speechBubbleStartX; // ��ǳ���� ���� X ��ǥ
    public float speechBubbleEndX; // ��ǳ���� �� X ��ǥ
    public float playerStartX; // �÷��̾��� ���� X ��ǥ
    public float playerEndX; // �÷��̾��� �� X ��ǥ
    public float playerMoveSpeed; // �÷��̾� �̵� �ӵ�

    private void Update()
    {
        // �÷��̾��� X ��ǥ�� ����ȭ�Ͽ� speechBubble�� �̵� ��� X ��ǥ�� ���
        float normalizedPlayerX = Mathf.InverseLerp(playerStartX, playerEndX, playerTransform.position.x);

        // speechBubble�� X ��ǥ�� �÷��̾��� X ��ǥ�� �°� �����Ͽ� ��ǥ X ��ǥ�� ���
        float targetSpeechBubbleX = Mathf.Lerp(speechBubbleStartX, speechBubbleEndX, normalizedPlayerX);

        // ���� speechBubble�� X ��ǥ�� ��ǥ X ��ǥ ���̸� �÷��̾��� �̵� �ӵ��� �����Ͽ� ���ο� X ��ǥ�� ���
        float currentSpeechBubbleX = speechBubbleRectTransform.anchoredPosition.x;
        float newSpeechBubbleX = Mathf.MoveTowards(currentSpeechBubbleX, targetSpeechBubbleX, playerMoveSpeed * Time.deltaTime);

        // speechBubble�� ��ġ�� ���ο� X ��ǥ�� ������Ʈ
        Vector2 newSpeechBubblePosition = new Vector2(newSpeechBubbleX, speechBubbleRectTransform.anchoredPosition.y);
        speechBubbleRectTransform.anchoredPosition = newSpeechBubblePosition;
    }
}

