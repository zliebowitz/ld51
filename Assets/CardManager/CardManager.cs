using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<GameObject> gameCards;  //Populate with inspector
    int max_hand_size; //Set based on gameCards setup.

    List<Card> deck = new List<Card>();
    List<Card> discard = new List<Card>();
    List<Card> hand = new List<Card>();
    int deck_size = 20;
    int initial_hand_size = 4;

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

    private void Awake()
    {
        max_hand_size = gameCards.Count;
        Color[] color_list = new Color[] { Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow };
        for (int i = 0; i < deck_size; i++)
        {
            Color color = color_list[Random.Range(0, color_list.Length)];
            deck.Add(new Card(color, "" + i, 0, "" + i));
        }
        // Not strictly needed at the itme of writing, but can deal with alter.
        Shuffle<Card>(deck);
        ApplyCards();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void NewTurn()
    {
        foreach (var c in hand)
            discard.Add(c);
        hand.Clear();
        for (int i = 0; i < initial_hand_size; i++)
            Draw();
    }

    public void Draw()
    {
        if (hand.Count == max_hand_size)
            return;
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

        ApplyCards();
    }

    void ApplyCards()
    {
        foreach (var gameCard in gameCards)
        {
            gameCard.GetComponent<GameCard>().ClearCard();
        }

        for (int index = 0; index < hand.Count; index++)
        {
            var card = hand[index];
            var gameCard = gameCards[index];

            gameCard.GetComponent<GameCard>().ApplyCard(card);
        }
    }

    public void PlayCard(Card card)
    {
        discard.Add(card);
        hand.Remove(card);
        card.Play();
        ApplyCards();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
