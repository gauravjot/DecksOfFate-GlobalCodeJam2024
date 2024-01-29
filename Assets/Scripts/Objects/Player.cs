using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private static List<Card> cards = new List<Card>();
    private static List<SupportCard> supportCards = new List<SupportCard>();

    private static int health = 100;

    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }

    public Player()
    {
        if (cards.Count < 1)
        {
            List<Card> allCards = AllCards.Instance.getAllCards();
            // Get random 4 cards but not the same
            while (cards.Count < 4)
            {
                int randomIndex = Random.Range(0, allCards.Count);
                Card randomCard = allCards[randomIndex];
                if (!cards.Contains(randomCard))
                {
                    cards.Add(randomCard);
                }
            }
        }
    }

    public void addSupportCard(SupportCard supportCard)
    {
        supportCards.Add(supportCard);
    }

    public List<SupportCard> getSupportCards()
    {
        return supportCards;
    }

    public void removeSupportCard(SupportCard supportCard)
    {
        supportCards.Remove(supportCard);
    }

    public List<Card> getPlayerCards()
    {
        return cards;
    }

    public void removeAllPlayerCards()
    {
        cards = new List<Card>();
        if (cards.Count < 1)
        {
            List<Card> allCards = AllCards.Instance.getAllCards();
            // Get random 4 cards but not the same
            while (cards.Count < 4)
            {
                int randomIndex = Random.Range(0, allCards.Count);
                Card randomCard = allCards[randomIndex];
                if (!cards.Contains(randomCard))
                {
                    cards.Add(randomCard);
                }
            }
        }
        supportCards = new List<SupportCard>();
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int newHealth)
    {
        health = newHealth;
    }
}
