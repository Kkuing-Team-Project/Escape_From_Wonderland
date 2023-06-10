using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 총알 프리팹
    public float bulletSpeed = 10f; // 총알 속도

    // Update 함수는 매 프레임마다 호출됩니다.
    private void Update()
    {
        // 스페이스 바를 눌렀을 때 총알을 발사합니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    // 총알을 발사하는 함수
    private void FireBullet()
    {
        // Bullet 프리팹을 인스턴스화합니다.
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 발사 방향을 설정하고 총알에 속도를 적용합니다.
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.up * bulletSpeed;

        // 플레이어의 회전값을 총알에도 적용합니다.
        bullet.transform.rotation = transform.rotation;
    }
}