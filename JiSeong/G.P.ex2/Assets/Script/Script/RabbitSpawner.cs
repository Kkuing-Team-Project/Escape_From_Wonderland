using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public GameObject rabbitPrefab; // �䳢 ������
    public List<float> tileYPositions; // Ÿ���� Y�� ����Ʈ
    public Transform playerTransform; // Player�� Transform

    public GameObject timePrefab; // Time ������
    public GameObject hatPrefab; // Hat ������
    public GameObject teaCupPrefab; // TeaCup ������

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
                    

                    // �䳢�� �����ϰ� ��ġ�� �����մϴ�.
                    float spawnPositionX = playerTransform.position.x + 10f;
                    SpawnRabbit(spawnPositionX);

                    // Time, Hat, TeaCup�� �����ϰ� �����մϴ�.
                    SpawnRandomCollectible(spawnPositionX);
                }
            }
            yield return new WaitForSeconds(2f); // 2�ʰ� ���
        }
            
    }

    void SpawnRandomCollectible(float xPosition)
    {
        // �����ϰ� Collectible�� �����մϴ�.
        int randomCollectible = Random.Range(0, 3);

        GameObject collectiblePrefab;

        // �����ϰ� ���õ� Collectible�� ���� �������� �����մϴ�.
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

        // �����ϰ� Ÿ�� �ε����� �����մϴ�.
        int randomTileIndex = Random.Range(0, tileYPositions.Count);

        // ������ Ÿ���� Y���� �����ɴϴ�.
        float tileY = tileYPositions[randomTileIndex];

        // Collectible�� �����ϰ� ��ġ�� �����մϴ�.
        GameObject collectible = Instantiate(collectiblePrefab, new Vector3(xPosition, tileY, 0f), Quaternion.identity);
    }

    void SpawnRabbit(float xPosition)
    {
        for(int i = 0; i < 6; i++)
        {
            // �����ϰ� Ÿ�� �ε����� �����մϴ�.
            int randomTileIndex = Random.Range(0, tileYPositions.Count);

            // ������ Ÿ���� Y���� �����ɴϴ�.
            float tileY = tileYPositions[randomTileIndex];

            // �䳢�� �����ϰ� ��ġ�� �����մϴ�.
            GameObject rabbit = Instantiate(rabbitPrefab, new Vector3(xPosition, tileY, 0f), Quaternion.identity);
        }

    }

    private void Update()
    {
        // �䳢 ������Ʈ�� x�� ��ǥ�� Player�� x ��ǥ - 10���� ������ �����մϴ�.
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