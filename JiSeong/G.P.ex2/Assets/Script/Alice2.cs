using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice2 : MonoBehaviour
{
    private Transform spaceshipTransform;
    public Vector3 offset;
    private Animator animator;

    IEnumerator Start()
    {
        spaceshipTransform = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        while (true)
        {
            yield return new WaitForSeconds(3);
            animator.SetInteger("AttackIndex", Random.Range(0, 1));
            animator.SetTrigger("Attack");
        }
    }

    private void Update()
    {
        if (spaceshipTransform != null)
        {
            Vector3 desiredPosition = spaceshipTransform.position + offset;
            transform.position = desiredPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroy");
        }
    }
}
