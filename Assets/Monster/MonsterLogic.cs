using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLogic : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.

    private UnitPhysics unitPhysics = new UnitPhysics();
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool attackStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        unitPhysics.Start(this);

        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            spriteRenderer.sortingOrder = (100 - (int)collider.bounds.min.y);
        }
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


        var closestMinion = unitPhysics.ClosestMinionDistance();
        if (closestMinion.Item2 <= unitStats.range)  //Attack Minions
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
            {

                if (attackStarted)
                {
                    if (unitStats.attackAllInRange)
                    {
                        GameObject[] gos = unitPhysics.FindAllGameObjectsWithTagInRange("Minion", unitStats.range);
                        foreach(GameObject go in gos)
                        {
                            MinionLogic ml = go.GetComponent<MinionLogic>();
                            if (ml != null)
                            {
                                ml.Hit(unitStats.damage);
                            }
                        }

                    }
                    else
                    {
                        MinionLogic ml = closestMinion.Item1.GetComponent<MinionLogic>();
                        if (ml != null)
                        {
                            ml.Hit(unitStats.damage);
                        }
                    }

                    if (unitStats.selfDestructOnAttack)
                    {
                        Hit(unitStats.health);
                        spriteRenderer.enabled = false;
                    }
                    attackStarted = false;
                }
                animator.SetTrigger("Attack");
                
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                attackStarted = true;
            }


        }
        else if (unitPhysics.TowerDistance() <= unitStats.range) //Attack Tower State
        {

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
            {
                if (attackStarted)
                {
                    unitPhysics.TowerHit(unitStats.damage);

                    if (unitStats.selfDestructOnAttack)
                    {
                        Hit(unitStats.health);
                        spriteRenderer.enabled = false;
                    }
                    attackStarted = false;
                }

                animator.SetTrigger("Attack");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                attackStarted = true;
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

    internal void Hit(int damage)
    {
        unitStats.health -= damage;
        if (unitStats.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
