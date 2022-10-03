using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameCard : MonoBehaviour
{
    public UnityEvent<Card> onClickEvent;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {
        onClickEvent.Invoke(card);
    }
}
