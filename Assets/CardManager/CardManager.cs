using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    List<Card> deck = new List<Card>();

    List<Card> discard = new List<Card>();

    List<Card> hand = new List<Card>();

    int deck_size = 20;

    int initial_hand_size = 4;

    int max_hand_size = 7;

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int other = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[other];
            list[other] = temp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deck_size; i++)
        {
            deck.Add(new Card());
        }
        // Not strictly needed at the itme of writing, but can deal with alter.
        Shuffle<Card>(deck);
        
    }

    void NewTurn()
    {
        foreach (var c in hand)
            discard.Add(c);
        hand.Clear();
        for (int i = 0; i < initial_hand_size; i++)
            Draw();
    }

    void Draw()
    {
        if (deck.Count == 0)
        {
            foreach (var card in discard)
            {
                deck.Add(card);
            }
            discard.Clear();
            Shuffle(deck);
         }
        Card c = deck[0];
        hand.Add(c);
        deck.RemoveAt(0);
        if (hand.Count > max_hand_size)
            throw new System.Exception("invalid hand size - exceeded max");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
