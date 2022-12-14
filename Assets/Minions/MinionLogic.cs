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
        var closestMonster = unitPhysics.ClosestMonsterDistance();
        if (closestMonster.Item2 <= unitStats.range)  //Attack Minions
        {

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetBool("Attack"))
            {
                if(attackStarted)
                {
                    if (unitStats.attackAllInRange)
                    {
                        GameObject[] gos = unitPhysics.FindAllMonstersnRange(unitStats.range + 15);
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
                        spriteRenderer.enabled = false;// Suppose to make it disappear.
                        Hit(unitStats.health);
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
		
		if (transform.position.x > 240)
		{
			transform.position = new Vector3(240, transform.position.y,  transform.position.z);
		}
    }

    internal void Hit(int damage)
    {
        unitStats.health -= damage;
        if(unitStats.health <= 0)
        {
            GameObject myPrefab = Resources.Load<GameObject>("Boom");
            Instantiate(myPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    public void recevieDamage(int damage)
    {
        unitStats.health += damage;
    }
}
