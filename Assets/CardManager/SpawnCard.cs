using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SpawnCard : Card
{
    public GameObject prefab;
    public Transform spawnLocation;

    public override void Play()
    {
        UnityEngine.Object.Instantiate(prefab, spawnLocation.position, Quaternion.identity);
    }

}
