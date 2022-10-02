using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCard : MonoBehaviour
{
    CardManager manager = null;
    Card card = null;
    public SpriteRenderer squareRenderer = null;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI description;

    public void ApplyCard(Card card)
    {
        this.card = card;
        gameObject.SetActive(true);
        squareRenderer.sprite = card.sprite;
        squareRenderer.color = Color.white;
        nameText.text = card.name;
        cost.text = "" + card.cost;
        description.text = card.description;
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
