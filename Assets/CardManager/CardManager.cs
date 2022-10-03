using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public List<GameObject> gameCards;  //Populate with inspector
    int max_hand_size; //Set based on gameCards setup.
    public int min_mana_total = 2;
    int mana_total;
    public int max_mana_total = 8;
    public TextMeshProUGUI mana_text;
    public List<SpawnCard> all_spawn_cards;
    public List<HealCard> all_heal_cards;
    public List<DamageCard> all_damage_cards;

    public List<GameObject> selectionCards;


    List<Card> all_cards = new List<Card>();

    List<Card> deck = new List<Card>();
    List<Card> discard = new List<Card>();
    List<Card> hand = new List<Card>();
    int cards_of_each = 3;
    int initial_hand_size = 4;
    int mana_used = 0;
    int hand_size_decrease = 0;

    public static void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int other = UnityEngine.Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[other];
            list[other] = temp;
        }
    }

    public static void Shuffle<T>(T[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            int other = UnityEngine.Random.Range(i, list.Length);
            T temp = list[i];
            list[i] = list[other];
            list[other] = temp;
        }
    }

    private void Awake()
    {
        max_hand_size = gameCards.Count;

        foreach (var c in all_spawn_cards)
            all_cards.Add(c);
        foreach (var c in all_heal_cards)
            all_cards.Add(c);
        foreach (var c in all_damage_cards)
            all_cards.Add(c);

        foreach (var card in all_cards)
        {
            if (card.is_starting)
            {
                for (int i = 0; i < cards_of_each; i++)
                {
                    deck.Add(card);
                }
            }
        }

        // Not strictly needed at the itme of writing, but can deal with alter.
        Shuffle<Card>(deck);
        ApplyCards();

        mana_total = min_mana_total;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EndTurn()
    {
        foreach (var c in hand)
            discard.Add(c);
        hand.Clear();
        ApplyCards();
    }

    public void NewTurn()
    {
        mana_used = 0;
        int hand_size = initial_hand_size - hand_size_decrease;
        for (int i = 0; i < hand_size; i++)
            Draw();
        hand_size_decrease = Math.Max(0, hand_size_decrease - initial_hand_size);
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
        if (card.cost + mana_used > mana_total)
            return;
        mana_used += card.cost;
        hand.Remove(card);
        card.Play();
        discard.Add(card);
        ApplyCards();
    }


    public void DecreaseNextHandSize()
    {
        hand_size_decrease++;
    }

    // Update is called once per frame
    void Update()
    {
        mana_text.text = (mana_total - mana_used) + " / " + mana_total;
    }


    public void OfferCards()
    {
        List<Card> already_selected = new List<Card>();
        foreach (var gc in selectionCards)
        {
            int i;
            do
            {
                i = UnityEngine.Random.Range(0, all_cards.Count);
            } while (all_cards[i].is_starting || already_selected.Contains(all_cards[i]));
            gc.GetComponent<GameCard>().ApplyCard(all_cards[i]);
            already_selected.Add(all_cards[i]);
        }
    }


    public void AddCard(Card card)
    {
        // This feels a bit more traditional than adding to the deck.
        discard.Add(card);
    }

    public void AddMoreMana()
    {
        mana_total = Math.Min(mana_total + 1, max_mana_total);
    }
}
