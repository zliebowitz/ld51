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

    public Tuple<GameObject, float> ClosestMonsterDistance()
    {
        string tag = "Monster";
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(tag + " Found: " + gos.Length);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = gameObject.transform.position;
        foreach (GameObject go in gos)
        {
            Collider2D gocolider = go.GetComponent<Collider2D>();
            ColliderDistance2D colliderDistance = collider.Distance(gocolider);

            float curDistance = colliderDistance.distance;
            if (curDistance < distance)
            {
                MonsterLogic logic = go.GetComponent<MonsterLogic>();
                if (logic.unitStats.health > 0)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        //Debug.Log("Closest " + tag + " with gameobject: " + closest.ToString() + " Distance: " + distance.ToString());
        return new Tuple<GameObject, float>(closest, distance);
    }

    public Tuple<GameObject, float> ClosestMinionDistance()
    {
        string tag = "Minion";
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(tag + " Found: " + gos.Length);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = gameObject.transform.position;
        foreach (GameObject go in gos)
        {
            Collider2D gocolider = go.GetComponent<Collider2D>();
            ColliderDistance2D colliderDistance = collider.Distance(gocolider);

            float curDistance = colliderDistance.distance;
            if (curDistance < distance)
            {
                MinionLogic logic = go.GetComponent<MinionLogic>();
                if (logic.unitStats.health > 0)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        //Debug.Log("Closest " + tag + " with gameobject: " + closest.ToString() + " Distance: " + distance.ToString());
        return new Tuple<GameObject, float>(closest, distance);
    }

    public GameObject[] FindAllMinionsInRange(float range)
    {
        string tag = "Minion";
        List<GameObject> rtn = new List<GameObject>();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(tag + " Found: " + gos.Length);
        Vector3 position = gameObject.transform.position;
        foreach (GameObject go in gos)
        {
            Collider2D gocolider = go.GetComponent<Collider2D>();
            ColliderDistance2D colliderDistance = collider.Distance(gocolider);

            float curDistance = colliderDistance.distance;
            if (curDistance <= range)
            {
                MinionLogic logic = go.GetComponent<MinionLogic>();
                if (logic.unitStats.health > 0)
                    rtn.Add(go);
            }
        }

        return rtn.ToArray();
    }

    public GameObject[] FindAllMonstersnRange(float range)
    {
        string tag = "Monster";
        List<GameObject> rtn = new List<GameObject>();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        //Debug.Log(tag + " Found: " + gos.Length);
        Vector3 position = gameObject.transform.position;
        foreach (GameObject go in gos)
        {
            Collider2D gocolider = go.GetComponent<Collider2D>();
            ColliderDistance2D colliderDistance = collider.Distance(gocolider);

            float curDistance = colliderDistance.distance;
            if (curDistance <= range)
            {
                MonsterLogic logic = go.GetComponent<MonsterLogic>();
                if (logic.unitStats.health > 0)
                    rtn.Add(go);
            }
        }

        return rtn.ToArray();
    }

    public float TowerDistance()
    {
        ColliderDistance2D colliderDistance = collider.Distance(towerColider);
        return colliderDistance.distance;
    }

    internal void TowerHit(int damage)
    {
        Tower t = tower.GetComponent<Tower>();
        if (t != null)
        {
            t.Hit(damage);
        }
    }

}
