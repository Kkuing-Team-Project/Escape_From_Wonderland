using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public GameObject objectA;
    public Slider slider;
    private float collisionValueDecrease; // 충돌 시 감소할 값

    private RectTransform sliderRectTransform;
    private RectTransform canvasRectTransform;

    private void Start()
    {
        sliderRectTransform = slider.GetComponent<RectTransform>();
        canvasRectTransform = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        if (objectA.CompareTag("Alien"))
        {
            slider.value = 50;
        }
        
        if (objectA.CompareTag("Asteroid"))
        {
            slider.value = 20;
        }
    }

    private void Update()
    {
        Vector2 objectAPosition = objectA.transform.position;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(objectAPosition);
        Vector2 sliderPosition = new Vector2(
            (viewportPosition.x * canvasRectTransform.sizeDelta.x) - (canvasRectTransform.sizeDelta.x * 0.5f),
            (viewportPosition.y * canvasRectTransform.sizeDelta.y) - (canvasRectTransform.sizeDelta.y * 0.5f)
        );

        sliderRectTransform.anchoredPosition = sliderPosition;

        GameObject spaceshipObject = GameObject.Find("Spaceship(Clone)");
        GameObject spaceshipObject2 = GameObject.Find("Spaceship 1(Clone)");
        if (spaceshipObject != null){
            collisionValueDecrease = 10;
        }

        else if (spaceshipObject2 != null){
            collisionValueDecrease = 20f;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !objectA.CompareTag("Planet")) // 충돌하는 오브젝트의 태그를 지정해야 함
        {
            slider.value -= collisionValueDecrease;

            if(slider.value <= 0){
                Destroy(gameObject);
                if(gameObject.CompareTag("Alien") || gameObject.CompareTag("Alien2")) KillCounter.instance.ailenKill++;
                if(gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Asteroid2")) KillCounter.instance.meteorKill++;      
            }
        }
    }
}
