using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public List<GameObject> gameCards;  //Populate with inspector
    int max_hand_size; //Set based on gameCards setup.
    public int mana_total;
    public TextMeshProUGUI mana_text;

    List<Card> deck = new List<Card>();
    List<Card> discard = new List<Card>();
    List<Card> hand = new List<Card>();
    int cards_of_each = 5;
    int initial_hand_size = 4;
    int mana_used = 0;
    public GameObject ancient_relic_fab;
    public GameObject mech_caster_fab;
    public GameObject scrap_pusher_fab;
    public GameObject tamed_fab;
    public Transform minionSpawnPoint;

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
        Vector3 towerLocation = minionSpawnPoint.position;
        for (int i = 0; i < cards_of_each; i++)
        {
            Color color = color_list[Random.Range(0, color_list.Length)];
            deck.Add(new Card(color, "Ancient Relic " + i, Random.Range(0, 4), "Anceint relics were found from eons ago that have somehow not fell apart ... This game is totally realisitc. AMIRITE?", ancient_relic_fab, towerLocation));
            deck.Add(new Card(color, "Mech Caster " + i, Random.Range(0, 4), "Humans have combined the old nad new world to create a monstrosity that should not exist ... How long til it turns? AMIRITE?", mech_caster_fab, towerLocation));
            deck.Add(new Card(color, "Scrap Pusher " + i, Random.Range(0, 4), "Push what you don't need? Better than scrapping it? AMIRITE?", scrap_pusher_fab, towerLocation));
            deck.Add(new Card(color, "Tamed " + i, Random.Range(0, 4), "Also known as whipped! AMIRITE?", tamed_fab, towerLocation));
        }
        // Not strictly needed at the itme of writing, but can deal with alter.
        Shuffle<Card>(deck);
        ApplyCards();
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
        if (card.cost + mana_used > mana_total)
            return;
        mana_used += card.cost;
        hand.Remove(card);
        card.Play();
        discard.Add(card);
        ApplyCards();
    }

    // Update is called once per frame
    void Update()
    {
        mana_text.text = (mana_total - mana_used) + " / " + mana_total;
    }
}
