using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject effectPrefab; // 이펙트 프리팹을 할당하기 위한 변수

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Rabbit"))
        {
            Player.instance.KillCountNull++;

            Destroy(collision.gameObject);
            Destroy(gameObject);

            // 이펙트를 생성하고 충돌 지점에 배치
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            print("rrr");

            // 이펙트 재생이 끝나면 제거
            
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

}
