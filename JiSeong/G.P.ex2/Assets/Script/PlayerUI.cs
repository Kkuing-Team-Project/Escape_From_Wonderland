using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Transform playerTransform;
    public RectTransform speechBubbleRectTransform;
    public float speechBubbleStartX;
    public float speechBubbleEndX;
    public float playerStartX;
    public float playerEndX;
    public float playerMoveSpeed;

    private void Update()
    {
        float normalizedPlayerX = Mathf.InverseLerp(playerStartX, playerEndX, playerTransform.position.x);
        float targetSpeechBubbleX = Mathf.Lerp(speechBubbleStartX, speechBubbleEndX, normalizedPlayerX);

        float currentSpeechBubbleX = speechBubbleRectTransform.anchoredPosition.x;
        float newSpeechBubbleX = Mathf.MoveTowards(currentSpeechBubbleX, targetSpeechBubbleX, playerMoveSpeed * Time.deltaTime);

        Vector2 newSpeechBubblePosition = new Vector2(newSpeechBubbleX, speechBubbleRectTransform.anchoredPosition.y);
        speechBubbleRectTransform.anchoredPosition = newSpeechBubblePosition;
    }
}
