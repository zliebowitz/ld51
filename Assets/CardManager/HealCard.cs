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
            // NOTE: ignore max health
            stats.health = stats.health + heal_amount;
        }
    }

}
