using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public float followDistance = 5f;
    public float attackDistance = 2f;
    public float movementSpeed = 5f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();

        while (true)
        {
            float attackDelay = Random.Range(3f, 5f); // 3�ʿ��� 5�� ������ ���� ������
            yield return new WaitForSeconds(attackDelay);

            // �÷��̾���� �Ÿ��� 0���� 2 ���̷� ����
            float targetX = player.position.x + Random.Range(-attackDistance, attackDistance);
            Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

            StartCoroutine(MoveToTarget(targetPosition));

            animator.SetInteger("AttackIndex", Random.Range(0, 2));
            animator.SetTrigger("Attack");
        }
    }

    private void Update()
    {
        float targetX = player.position.x - followDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
