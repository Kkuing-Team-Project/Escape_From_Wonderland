using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public GameObject rabbitPrefab; // �䳢 ������
    public List<float> tileYPositions; // Ÿ���� Y�� ����Ʈ
    public Transform playerTransform; // Player�� Transform

    private void Start()
    {
        // Ÿ�� ������ Y���� ������ ��ġ�ϴ��� Ȯ��
        if (tileYPositions.Count != 7)
        {
            Debug.LogError("Ÿ�� ������ Y�� ������ ��ġ���� �ʽ��ϴ�!");
            return;
        }

        StartCoroutine(SpawnRabbitsRepeatedly());
    }

    IEnumerator SpawnRabbitsRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // 2�ʰ� ���

            // �䳢�� �����ϰ� ��ġ�� �����մϴ�.
            SpawnRabbit(playerTransform.position.x + 10f);
        }
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