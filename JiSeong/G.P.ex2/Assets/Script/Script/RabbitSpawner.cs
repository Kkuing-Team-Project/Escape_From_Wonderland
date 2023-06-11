using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public GameObject rabbitPrefab; // 토끼 프리팹
    public List<float> tileYPositions; // 타일의 Y값 리스트
    public Transform playerTransform; // Player의 Transform

    private void Start()
    {
        // 타일 개수와 Y값의 개수가 일치하는지 확인
        if (tileYPositions.Count != 7)
        {
            Debug.LogError("타일 개수와 Y값 개수가 일치하지 않습니다!");
            return;
        }

        StartCoroutine(SpawnRabbitsRepeatedly());
    }

    IEnumerator SpawnRabbitsRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // 2초간 대기

            // 토끼를 생성하고 위치를 설정합니다.
            SpawnRabbit(playerTransform.position.x + 10f);
        }
    }

    void SpawnRabbit(float xPosition)
    {
        for(int i = 0; i < 6; i++)
        {
            // 랜덤하게 타일 인덱스를 선택합니다.
            int randomTileIndex = Random.Range(0, tileYPositions.Count);

            // 선택한 타일의 Y값을 가져옵니다.
            float tileY = tileYPositions[randomTileIndex];

            // 토끼를 생성하고 위치를 설정합니다.
            GameObject rabbit = Instantiate(rabbitPrefab, new Vector3(xPosition, tileY, 0f), Quaternion.identity);
        }

    }

    private void Update()
    {
        // 토끼 오브젝트의 x축 좌표가 Player의 x 좌표 - 10보다 작으면 삭제합니다.
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        foreach (GameObject rabbit in rabbits)
        {
            if (rabbit.transform.position.x <= playerTransform.position.x - 10f)
            {
                Destroy(rabbit);
            }
        }
    }
}