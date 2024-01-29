using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch2S3_Farmer : MonoBehaviour
{
    [SerializeField]
    Image card1;

    [SerializeField]
    Sprite supportCardApple;

    [SerializeField]
    Sprite supportCardCheese;

    [SerializeField]
    Sprite supportCardGoat;

    // Start is called before the first frame update
    void Start()
    {
        Player player = Player.Instance;
        AllCards allCards = AllCards.Instance;
        List<SupportCard> supportCards = allCards.getSupportCards();
        // Get random support card
        int randomIndex = Random.Range(0, supportCards.Count);
        player.addSupportCard(supportCards[randomIndex]);

        if (supportCards[randomIndex].id == 0)
        {
            card1.sprite = supportCardApple;
        }
        else if (supportCards[randomIndex].id == 1)
        {
            card1.sprite = supportCardCheese;
        }
        else if (supportCards[randomIndex].id == 2)
        {
            card1.sprite = supportCardGoat;
        }
    }

    // Update is called once per frame
    void Update() { }
}
