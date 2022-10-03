using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCaster : MonoBehaviour
{
    bool wasPreviousAttack = false;
    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        if (!wasPreviousAttack && isAttack)
        {
            FindObjectOfType<AudioManager>().PlaySound("Gunshot");
        }

        wasPreviousAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    }

}
