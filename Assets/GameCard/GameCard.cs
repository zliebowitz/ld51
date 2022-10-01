using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard : MonoBehaviour
{
    CardManager manager = null;
    int index = -1;

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


    public void setManagerAndIndex(CardManager manager, int index)
    {
        this.manager = manager;
        this.index = index;
    }


    void OnMouseDown()
    {
        manager.PlayCard(index);
        // NOTE: the manager is in charge of refreshing afterwards.
    }
}
