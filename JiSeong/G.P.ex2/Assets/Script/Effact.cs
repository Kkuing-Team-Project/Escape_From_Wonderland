using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effact : MonoBehaviour
{
    private Animator self;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (self.GetCurrentAnimatorStateInfo(0).length < self.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            Destroy(gameObject);
        }
    }
}
