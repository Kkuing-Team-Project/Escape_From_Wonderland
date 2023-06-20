using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotation : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject objectD;

    private bool objectsActive = false;
    public float rotationSpeed = 100f;

    private AudioSource audioSource;
    public AudioClip soundClip; // 재생할 사운드 클립

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // 초기에는 objectA, objectB, objectC를 비활성화
        SetObjectsActive(false);
    }

    private void Update()
    {
        RotateObject(objectA, -rotationSpeed);
        RotateObject(objectB, -rotationSpeed);
        RotateObject(objectC, -rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ESC 키를 누르면 활성화 또는 비활성화 상태를 토글
            objectsActive = !objectsActive;
            SetObjectsActive(objectsActive);
            PlaySound();
        }
    }

    private void PlaySound()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
    }

    private void RotateObject(GameObject obj, float speed)
    {
        obj.transform.RotateAround(objectD.transform.position, Vector3.forward, speed * Time.deltaTime);
    }

    private void SetObjectsActive(bool active)
    {
        objectA.SetActive(active);
        objectB.SetActive(active);
        objectC.SetActive(active);
    }
}
