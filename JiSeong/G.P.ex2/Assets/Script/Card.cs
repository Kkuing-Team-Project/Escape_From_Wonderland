using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject effectPrefab; // ����Ʈ �������� �Ҵ��ϱ� ���� ����

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Rabbit") && gameObject.CompareTag("Card"))
        {
            Player.instance.KillCountNull++;
            Destroy(collision.gameObject);
            StartCoroutine(DestroyAfterDelay(1f));

            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        Vector3 P = this.gameObject.transform.position;
        transform.position += Vector3.right * Time.deltaTime * 12;
        transform.Rotate(0, 0, 90);

        if (pos.x < P.x)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // delay초 동안 대기
        Destroy(gameObject); // GameObject 파괴
    }
}
