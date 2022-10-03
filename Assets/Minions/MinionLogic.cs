using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLogic : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.

    private UnitPhysics unitPhysics = new UnitPhysics();
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    bool attackStarted = false;

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
        var closestMonster = unitPhysics.ClosestMonsterDistance();
        if (closestMonster.Item2 <= unitStats.range)  //Attack Minions
        {

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
            {
                if(attackStarted)
                {
                    if (unitStats.attackAllInRange)
                    {
                        GameObject[] gos = unitPhysics.FindAllGameObjectsWithTagInRange("Monster", unitStats.range);
                        foreach (GameObject go in gos)
                        {
                            MonsterLogic ml = go.GetComponent<MonsterLogic>();
                            if (ml != null)
                            {
                                ml.Hit(unitStats.damage);
                            }
                        }

                    }
                    else
                    {
                        MonsterLogic ml = closestMonster.Item1.GetComponent<MonsterLogic>();
                        if (ml != null)
                        {
                            ml.Hit(unitStats.damage);
                        }
                    }



                    if(unitStats.selfDestructOnAttack)
                    {
                        Hit(unitStats.health);
                        spriteRenderer.enabled = false;
                    }
                    attackStarted = false;
                }


                animator.SetTrigger("Attack");

            }
            else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                attackStarted = true;
            }
           

        }
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

    internal void Hit(int damage)
    {
        unitStats.health -= damage;
        if(unitStats.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void recevieDamage(int damage)
    {
        unitStats.health += damage;
    }
}
