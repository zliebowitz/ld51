using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Custom serializable class
[Serializable]
public class UnitStats
{
    public int maxhealth;
    public int health;
    public int damage;
    public int range;
    public int speed;
    public bool selfDestructOnAttack = false;
    public bool attackAllInRange = false;
}
