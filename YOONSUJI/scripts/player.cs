using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    private Vector3 vector;
    private int currentWalkCount;
    public int walkcount;
    private bool canMove = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") !=0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
            if(vector.x != 0)
            {
                vector.y = 0;
            }
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);

            if (vector.x != 0)
            {
                transform.Translate(vector.x * speed, 0, 0);
            }
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * speed, 0);
            }

            yield return new WaitForSeconds(0.01f);

            currentWalkCount = 0;
        }
        canMove = true;
        animator.SetBool("Walking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }
        if(Input.GetKeyDown(KeyCode.Q)&& !animator.GetCurrentAnimatorStateInfo(0).IsName("run attack"))
        {
            animator.SetTrigger("run attack");
        }
    }
}
