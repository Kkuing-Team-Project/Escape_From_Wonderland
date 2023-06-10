using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public GameObject rabbitPrefab; // �䳢 ������
    public List<float> tileYPositions; // Ÿ���� Y�� ����Ʈ

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

            // �䳢 ������ 6�� �ݺ��մϴ�.
            for (int i = 0; i < 6; i++)
            {
                // �����ϰ� Ÿ�� �ε����� �����մϴ�.
                int randomTileIndex = Random.Range(0, tileYPositions.Count);

                // ������ Ÿ���� Y���� �����ɴϴ�.
                float tileY = tileYPositions[randomTileIndex];

                // �䳢�� �����ϰ� ��ġ�� �����մϴ�.
                GameObject rabbit = Instantiate(rabbitPrefab, new Vector3(10f, tileY, 0f), Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        // �䳢 ������Ʈ�� x�� ��ǥ�� -8.99�� �Ǹ� �����մϴ�.
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        foreach (GameObject rabbit in rabbits)
        {
            if (rabbit.transform.position.x <= -8.99f)
            {
                Destroy(rabbit);
            }
        }
    }
}
