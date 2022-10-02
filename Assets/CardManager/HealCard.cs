using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealCard : Card
{

    public int heal_amount;

    public override void Play()
    {
        GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
        foreach (var minion in minions)
        {
            MinionLogic logic = minion.GetComponent<MinionLogic>();
            if (logic == null)
                continue;
            UnitStats stats = logic.unitStats;
            if (stats == null)
                continue;
            // TODO: add max health
            stats.health = Math.Min(stats.health + heal_amount, stats.maxhealth);
        }
    }

}
