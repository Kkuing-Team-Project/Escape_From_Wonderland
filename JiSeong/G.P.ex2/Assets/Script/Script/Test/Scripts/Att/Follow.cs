using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform target;
    public float ObjectSpd = 15f;

    // Start is called before the first frame update
    void Start() {
        target = Kkuing.instance.transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        // 플레이어를 향해 이동하는 벡터 계산
        Vector3 direction = (target.position - transform.position).normalized;

        // 오브젝트 이동
        transform.position += direction * ObjectSpd * Time.deltaTime;
    }
}
