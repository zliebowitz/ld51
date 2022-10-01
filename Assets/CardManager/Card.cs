using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Color color;

    private static Color[] color_list = new Color[] { Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow};

    public Card()
    {
        color = color_list[Random.Range(0, color_list.Length)];
    }

}
