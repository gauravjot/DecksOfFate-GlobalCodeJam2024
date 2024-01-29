using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight5 : MonoBehaviour
{
    [SerializeField]
    Image card1;

    [SerializeField]
    Sprite giftCard;

    [SerializeField]
    Sprite couponsCard;

    [SerializeField]
    Sprite juiceBox;

    [SerializeField]
    Sprite stickyHand;

    // Start is called before the first frame update
    void Start()
    {
        // Get random support card
        int randomIndex = Random.Range(0, 4);

        if (randomIndex == 0)
        {
            card1.sprite = giftCard;
        }
        else if (randomIndex == 1)
        {
            card1.sprite = couponsCard;
        }
        else if (randomIndex == 2)
        {
            card1.sprite = juiceBox;
        }
        else
        {
            card1.sprite = stickyHand;
        }
    }

    // Update is called once per frame
    void Update() { }
}
