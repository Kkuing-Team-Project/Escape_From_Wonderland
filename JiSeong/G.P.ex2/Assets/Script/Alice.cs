using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();
        while(true)
        {
            yield return new WaitForSeconds(3);

            animator.SetInteger("AttackIndex", Random.Range(0, 2));
            animator.SetTrigger("Attack");
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "Player") //내 프로젝트 내 플레이어 이름이 move라 맞춰서 수정하세요
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroy");
        }
    }
    

}
