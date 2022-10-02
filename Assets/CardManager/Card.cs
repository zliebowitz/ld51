using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Card
{
    public Sprite sprite;

    public string name;
    public int cost;
    public string description;
    public Boolean is_starting;

    public abstract void Play();
}
