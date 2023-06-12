using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public GameObject rabbitPrefab; // 토끼 프리팹
    public List<float> tileYPositions; // 타일의 Y값 리스트
    public Transform playerTransform; // Player의 Transform

    public GameObject timePrefab; // Time 프리팹
    public GameObject hatPrefab; // Hat 프리팹
    public GameObject teaCupPrefab; // TeaCup 프리팹

    private void Start()
    {
        StartCoroutine(SpawnRabbitsRepeatedly());
    }

    IEnumerator SpawnRabbitsRepeatedly()
    {
        while (true)
        {
            if(Player.instance != null)
            {
                int num = Player.instance.PlayGame;
                if (num != 0)
                {
                    

                    // 토끼를 생성하고 위치를 설정합니다.
                    float spawnPositionX = playerTransform.position.x + 10f;
                    SpawnRabbit(spawnPositionX);

                    // Time, Hat, TeaCup을 랜덤하게 생성합니다.
                    SpawnRandomCollectible(spawnPositionX);
                }
            }
            yield return new WaitForSeconds(2f); // 2초간 대기
        }
            
    }

    void SpawnRandomCollectible(float xPosition)
    {
        // 랜덤하게 Collectible을 선택합니다.
        int randomCollectible = Random.Range(0, 3);

        GameObject collectiblePrefab;

        // 랜덤하게 선택된 Collectible에 따라 프리팹을 설정합니다.
        switch (randomCollectible)
        {
            case 0:
                collectiblePrefab = timePrefab;
                break;
            case 1:
                collectiblePrefab = hatPrefab;
                break;
            case 2:
                collectiblePrefab = teaCupPrefab;
                break;
            default:
                return;
        }

        // 랜덤하게 타일 인덱스를 선택합니다.
        int randomTileIndex = Random.Range(0, tileYPositions.Count);

        // 선택한 타일의 Y값을 가져옵니다.
        float tileY = tileYPositions[randomTileIndex];

        // Collectible을 생성하고 위치를 설정합니다.
        GameObject collectible = Instantiate(collectiblePrefab, new Vector3(xPosition, tileY, 0f), Quaternion.identity);
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