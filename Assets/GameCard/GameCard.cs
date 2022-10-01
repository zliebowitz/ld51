using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    public void ApplyCard(Card card)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = card.color;
    }

    public void ClearCard()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
