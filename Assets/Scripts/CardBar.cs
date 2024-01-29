using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBar : MonoBehaviour
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
    Image card5;

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

    [SerializeField]
    Sprite SupportCardGoat;

    [SerializeField]
    Sprite SupportCardApple;

    [SerializeField]
    Sprite SupportCardCheese;

    // Start is called before the first frame update
    void Start()
    {
        Player player = Player.Instance;
        for (int i = 0; i < 4; i++)
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
            Card card = player.getPlayerCards()[i];
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

        if (player.getSupportCards().Count > 0)
        {
            if (player.getSupportCards()[0].id == 0)
            {
                card5.sprite = SupportCardApple;
            }
            else if (player.getSupportCards()[0].id == 1)
            {
                card5.sprite = SupportCardCheese;
            }
            else if (player.getSupportCards()[0].id == 2)
            {
                card5.sprite = SupportCardGoat;
            }
        }
        else
        {
            card5.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() { }
}
