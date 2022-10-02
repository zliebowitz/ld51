using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLogic : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.

    private UnitPhysics unitPhysics = new UnitPhysics();
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        unitPhysics.Start(this);

        spriteRenderer.sortingOrder = (100 - (int)transform.position.y);
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

        if (unitPhysics.ClosestMonsterDistance() <= unitStats.range)  //Attack Minions
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
            {
                animator.SetTrigger("Attack");

            }
        }
        /*        else if (unitPhysics.TowerDistance() <= unitStats.range) //Attack Tower State
                {

                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
                    {
                        animator.SetTrigger("Attack");
                        unitPhysics.TowerHit(unitStats.damage);
                    }


                }*/
        else //Move to Right
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Move") && !animator.GetBool("Move"))
            {
                animator.SetTrigger("Move");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
            {
                transform.position += Vector3.right * unitStats.speed * Time.fixedDeltaTime;
            }
        }
    }
}
