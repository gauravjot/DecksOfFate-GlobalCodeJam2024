using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScene2 : MonoBehaviour
{
    [SerializeField]
    Image card1;

    [SerializeField]
    Image card2;

    [SerializeField]
    Image card3;

    [SerializeField]
    Image card4;

    [SerializeField]
    Sprite PrincessSailor;

    [SerializeField]
    Sprite CommunityWizard;

    [SerializeField]
    Sprite BussinessMan;

    [SerializeField]
    Sprite Vampire;

    [SerializeField]
    Sprite NotZombie;

    [SerializeField]
    Sprite Catstronaut;

    [SerializeField]
    Sprite SpaghettiBowl;

    [SerializeField]
    Sprite AngryItalianChef;

    // Start is called before the first frame update
    void Start()
    {
        Player player = Player.Instance;
        List<Card> cards = player.getPlayerCards();

        for (int i = 0; i < cards.Count; i++)
        {
            // Choose card image holder
            Image cardImage;
            if (i == 0)
            {
                cardImage = card1;
            }
            else if (i == 1)
            {
                cardImage = card2;
            }
            else if (i == 2)
            {
                cardImage = card3;
            }
            else
            {
                cardImage = card4;
            }

            Card card = cards[i];
            if (card.id == (int)AllCards.CardTypes.PrincessSailor)
            {
                // Princess Sailer
                cardImage.sprite = PrincessSailor;
            }
            else if (card.id == (int)AllCards.CardTypes.BusinessMan)
            {
                cardImage.sprite = BussinessMan;
            }
            else if (card.id == (int)AllCards.CardTypes.Wizard)
            {
                cardImage.sprite = CommunityWizard;
            }
            else if (card.id == (int)AllCards.CardTypes.Vampire)
            {
                cardImage.sprite = Vampire;
            }
            else if (card.id == (int)AllCards.CardTypes.NotZombie)
            {
                cardImage.sprite = NotZombie;
            }
            else if (card.id == (int)AllCards.CardTypes.Spaghetti)
            {
                cardImage.sprite = SpaghettiBowl;
            }
            else if (card.id == (int)AllCards.CardTypes.Catstronaut)
            {
                cardImage.sprite = Catstronaut;
            }
            else if (card.id == (int)AllCards.CardTypes.AngryItalianChef)
            {
                cardImage.sprite = AngryItalianChef;
            }
        }
    }
}
