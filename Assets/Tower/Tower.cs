using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public UnitStats unitStats; //populate in the inspector.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int damage)
    {
        unitStats.health -= damage;
        if(unitStats.health < 0)
        {
            GameObject loser = GameObject.Find("GameManager").transform.Find("LoseScreen").gameObject;
            loser.SetActive(true);
        }
    }
}
