using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formless : MonoBehaviour
{

    public UnitStats unitStats; //populate in the inspector.

    private UnitPhysics unitPhysics = new UnitPhysics();
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        unitPhysics.Start(this);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (TOKObjectController.GetPause())
        {
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Move");
            return;
        }

        if (unitPhysics.TowerDistance() <= unitStats.range) //Attack Tower State
        {

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
            {
                animator.SetTrigger("Attack");
                unitPhysics.TowerHit(unitStats.damage);
            }


        }
        else //Move to Tower State
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Move") && !animator.GetBool("Move"))
            {
                animator.SetTrigger("Move");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
            {
                transform.position += Vector3.left * unitStats.speed * Time.fixedDeltaTime;
            }
        }
    }
}
