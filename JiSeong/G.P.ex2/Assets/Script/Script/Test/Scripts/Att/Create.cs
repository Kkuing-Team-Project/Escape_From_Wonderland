using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Create : MonoBehaviour
{
    public GameObject[] meteors; // 운석 프리팹들을 저장할 배열
    public GameObject[] Alien; // 외계인 프리팹들을 저장할 배열

    private float spawnInterval = 3f; // 운석 생성 간격
    private float spawnInterval2 = 5f; // 외계인 생성 간격

    Kkuing player;
    private void Start()
    {
        player = Kkuing.instance;
        // 시작 시간에 바로 운석 & 외계인 생성

        SpawnMeteor();
        StartCoroutine(SpawnMeteorCoroutine()); // 일정 간격으로 운석 생성 코루틴 실행
        StartCoroutine(AlienrCoroutine()); // 일정 간격으로 외계인 생성 코루틴 실행
    }

    private void SpawnMeteor()
    {
        // 배열에서 랜덤한 운석 프리팹을 선택
        GameObject randomMeteor = meteors[Random.Range(0, meteors.Length)];

        // 랜덤한 위치에서 운석 생성
        float x, y;
        do{
            x = Random.Range(-40f, 40f);
            y = Random.Range(-40f, 40f);
        }while(x < 14 && y < 14);

        Vector3 spawnPosition = new Vector3(x, y, 0f); // x 범위는 -10부터 10까지, y는 10으로 고정

        // 랜덤한 위치에서 운석 생성
        Instantiate(randomMeteor, spawnPosition, Quaternion.identity);
    }

     private void SpawnAlien()
    {
        // 배열에서 랜덤한 외계인 프리팹을 선택
        GameObject randomAlien = Alien[Random.Range(0, Alien.Length)];
        
        // 랜덤한 위치에서 외계인 생성
        float x, y;
        do{
            x = Random.Range(-40f, 40f);
            y = Random.Range(-40f, 40f);
        }while(x < 14 && y < 14);

        Vector3 spawnPosition = new Vector3(x, y, 0f); // x 범위는 -10부터 10까지, y는 10으로 고정
        Instantiate(randomAlien, spawnPosition, Quaternion.identity);
    }


    private IEnumerator SpawnMeteorCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMeteor();
        }
    }

    private IEnumerator AlienrCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval2);
            SpawnAlien();
        }
    }
}

