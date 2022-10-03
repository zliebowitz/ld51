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
        UnityEngine.Object.Instantiate(prefab, spawnLocation.position + Vector3.up * UnityEngine.Random.Range(-10,10) + Vector3.right * UnityEngine.Random.Range(-50,50), Quaternion.identity);
    }

}
