using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public float minYPosition = -2.34f;
    public float maxYPosition = 2.34f;
    public float movementSpeed = 6f;
    public float minDelay = 1f;
    public float maxDelay = 3f;
    public float minAttackDelay = 3f;
    public float maxAttackDelay = 5f;
    public float minDistance = 5f;
    public float maxDistance = 20f;

    private float targetX;
    private float targetY;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();

        while (true)
        {
            float moveDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(moveDelay);

            targetX = player.position.x;
            targetY = Random.Range(minYPosition, maxYPosition);

            StartCoroutine(MoveToTarget(new Vector3(targetX, targetY, transform.position.z)));

            float attackDelay = Random.Range(minAttackDelay, maxAttackDelay);
            yield return new WaitForSeconds(attackDelay);

            animator.SetInteger("AttackIndex", Random.Range(0, 2));
            animator.SetTrigger("Attack");
        }
    }

    private void Update()
    {
        float distance = Mathf.Clamp(Random.Range(minDistance, maxDistance), minDistance, maxDistance);

        if (Mathf.Abs(transform.position.x - player.position.x) > distance)
        {
            targetX = player.position.x;
            targetY = Random.Range(minYPosition, maxYPosition);
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }

        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, targetY, transform.position.z), step);
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        while (transform.position != target)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            yield return null;
        }
    }
}
