using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UnitPhysics
{
    private MonoBehaviour unit;
    private GameObject gameObject;
    private Collider2D collider;
    private GameObject tower;
    private Collider2D towerColider;

    public void Start(MonoBehaviour self)
    {
        unit = self;
        gameObject = unit.gameObject;
        collider = gameObject.GetComponent<Collider2D>();
        tower = GameObject.Find("Tower");
        towerColider = tower.GetComponent<Collider2D>();
    }

    public float TowerDistance()
    {
        ColliderDistance2D colliderDistance = collider.Distance(towerColider);
        return colliderDistance.distance;
    }

    internal void TowerHit(int damage)
    {
        Tower t = tower.GetComponent<Tower>();
        if(t != null)
        {
            t.Hit(damage);
        }
    }
       
}
