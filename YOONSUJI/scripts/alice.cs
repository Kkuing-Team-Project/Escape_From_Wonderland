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
        if(collision.gameObject.name == "move") 
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroy");
        }
    }
    

}
