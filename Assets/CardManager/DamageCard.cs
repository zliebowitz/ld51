using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DamageCard : Card
{

    public int damage_amount;
    public bool all_entities;

    public override void Play()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var monster in monsters)
        {
            MonsterLogic logic = monster.GetComponent<MonsterLogic>();
            if (logic == null)
                continue;
            logic.Hit(damage_amount);
        }
        if (all_entities)
        {
            GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
            foreach (var minion in minions)
            {
                MinionLogic logic = minion.GetComponent<MinionLogic>();
                if (logic == null)
                    continue;
                logic.Hit(damage_amount);
            }
        }
    }

}
