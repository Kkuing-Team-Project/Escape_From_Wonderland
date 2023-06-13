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
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveToTarget(new Vector3(targetX, targetY, transform.position.z)));
    }

    private void Update()
    {
        float distance = Mathf.Clamp(Random.Range(minDistance, maxDistance), minDistance, maxDistance);

        // if (Mathf.Abs(transform.position.x - player.position.x) > distance)
        // {
        //     targetX = player.position.x;
        //     targetY = Random.Range(minYPosition, maxYPosition);
        //     transform.position = new Vector3(targetX, targetY, transform.position.z);
        // }

        // float step = movementSpeed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, targetY, transform.position.z), step);
    }
    IEnumerator MoveToTarget(Vector3 target)
    {
        float nextTime;
        float t=0f;
        
        while(true){
            t=0f;
            nextTime=Random.Range(minAttackDelay,maxAttackDelay);
            while (nextTime>t)
            {
                t+=Time.deltaTime;
                transform.position=Vector2.Lerp(transform.position, player.position,Time.deltaTime);
                yield return null;
            }
                    yield return StartCoroutine(Attack());
        }

    }
    IEnumerator Attack()
    {
        float t=0f;
        Debug.Log("testtstt");
        while(t<0.5f)
        {
            t+=Time.deltaTime*2f;
            transform.position=Vector2.Lerp(transform.position,player.position,t);
            yield return null;
        }
        animator.SetInteger("AttackIndex", 0);
        animator.SetTrigger("Attack");
        while(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="Alice")
            yield return null;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }
}
