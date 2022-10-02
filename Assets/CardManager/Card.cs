using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Color color;

    public string name;
    public int cost;
    public string description;
    private GameObject prefab;
    private Vector3 spawnLocation;

    public Card(Color color, string name, int cost, string description, GameObject prefab, Vector3 spawnLocation)
    {
        this.color = color;
        this.name = name;
        this.cost = cost;
        this.description = description;
        this.prefab = prefab;
        this.spawnLocation = spawnLocation;
    }

    public void Play()
    {
        Object.Instantiate(prefab, spawnLocation, Quaternion.identity);
    }
}
