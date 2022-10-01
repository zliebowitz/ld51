using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    CardManager manager = null;
    Card card = null;

    public void ApplyCard(Card card)
    {
        this.card = card;
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = card.color;
    }

    public void ClearCard()
    {
        card = null;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("CardManager").GetComponent<CardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {
        manager.PlayCard(card);
        // NOTE: the manager is in charge of refreshing afterwards.
    }
}
