using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossFightScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public Image imageAtComplete;
    public Image EnemyHealthBar;
    public TextMeshProUGUI textHealth;

    //[SerializeField]
    //RectTransform playerOptions;

    [SerializeField]
    RectTransform dialogBox;

    [SerializeField]
    string[] sentences;

    [Range(0f, 1f), SerializeField]
    float textSpeed = 0.05f;

    [SerializeField]
    int nextSceneIndex = 0;

    [SerializeField]
    Button card1;

    [SerializeField]
    Button card2;

    [SerializeField]
    Button card3;

    [SerializeField]
    Button card4;

    [SerializeField]
    Button supportCard1;

    [SerializeField]
    Sprite healthBarEmpty;

    [SerializeField]
    Sprite healthBar1_5th;

    [SerializeField]
    Sprite healthBar2_5th;

    [SerializeField]
    Sprite healthBar3_5th;

    [SerializeField]
    Sprite healthBar4_5th;

    [SerializeField]
    Sprite healthBar;

    int enemyHp = 250;
    private int stage = 0;
    private int lineIndex = 0;
    private bool isEnemyAttacking = false;
    private bool isPlayerAttacking = false;
    private bool isTyping = false;
    private bool wasItDamageAttack = false;

    private enum Buffs
    {
        DoubleDamage
    }

    private int buff = -1;

    private Player player;

    void winScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    void loseScene()
    {
        SceneManager.LoadScene(15);
    }

    void GiveAttackFeedback(int line)
    {
        lineIndex = line;
        StartCoroutine(TypeLine(line));
        imageAtComplete.enabled = false;
    }

    void GiveAttackFeedback(string line)
    {
        StartCoroutine(TypeLine(line));
        imageAtComplete.enabled = false;
    }

    private IEnumerator TypeLine(int line)
    {
        // dialogBox.gameObject.SetActive(true);
        textDisplay.text = string.Empty;
        isTyping = true;
        foreach (char letter in sentences[line].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 60);
        isTyping = false;
        imageAtComplete.enabled = true;
    }

    private IEnumerator TypeLine(string line)
    {
        textDisplay.text = string.Empty;
        isTyping = true;
        foreach (char letter in line.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 60);
        isTyping = false;
        imageAtComplete.enabled = true;
    }

    private IEnumerator EnemyAttackMessage(int line)
    {
        isEnemyAttacking = true;
        textDisplay.text = string.Empty;
        isTyping = true;
        foreach (char letter in sentences[line].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 60);
        isTyping = false;
        imageAtComplete.enabled = true;
        isEnemyAttacking = false;
        stage++;
        yield return null;
    }

    private IEnumerator RandomSquirrelAttack(int randomAttack)
    {
        isEnemyAttacking = true;
        if (randomAttack == 0)
        {
            // Bite Attack
            player.setHealth(player.getHealth() - 10);
        }
        else if (randomAttack == 1)
        {
            // Slash Attack
            player.setHealth(player.getHealth() - 10);
        }
        else if (randomAttack == 2)
        {
            // Great Sword Attack
            player.setHealth(player.getHealth() - 25);
        }
        else
        {
            // Rock Throw
            player.setHealth(player.getHealth() - 5);
        }

        textHealth.text = player.getHealth().ToString() + "%";

        if (player.getHealth() <= 0)
        {
            loseScene();
        }
        else if (enemyHp <= 0)
        {
            winScene();
        }
        else
        {
            stage++;
        }

        isEnemyAttacking = false;
        yield return null;
    }

    private IEnumerator PlayerAttackMessage()
    {
        isPlayerAttacking = true;
        textDisplay.text = string.Empty;
        isTyping = true;
        foreach (char letter in sentences[5].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
        imageAtComplete.enabled = true;
        isPlayerAttacking = false;
        stage++;
        yield return null;
    }

    private IEnumerator BossCurseMessages()
    {
        isPlayerAttacking = true;
        textDisplay.text = string.Empty;
        isTyping = true;
        List<string> curseMessages = new List<string>
        {
            "Frothgar: Uegh..?! Curse you!",
            "Frothgar: Is that what you call an attack? I barely felt a thing!",
            "Frothgar: You little pests!",
            "Oh, please, that tickled! Is that all you've got?",
            "Ha! I've been stung by mosquitoes with more bite!",
            "Ah, a gentle breeze would hurt more than that!",
            "Is that your battle cry or a kitten's meow?",
            "I've had tougher encounters with dandelions!",
            "I've been insulted by better insults!",
            "I've had paper cuts more threatening than your attacks!",
            "I've faced stronger gusts from a wheezing grandma!",
            "Your attacks are about as intimidating as a fluffy pillow!"
        };
        // Randomly choose a curse message
        int randomIndex = Random.Range(0, curseMessages.Count);
        foreach (char letter in curseMessages[randomIndex].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 40);
        isTyping = false;
        imageAtComplete.enabled = true;
        isPlayerAttacking = false;
        stage++;
        yield return null;
    }

    private void PlayerAttack(Card card)
    {
        string attackFeedback = card.attack_feeback;
        if (card.id == (int)AllCards.CardTypes.Catstronaut)
        {
            // odds for 50-50
            int odds = Random.Range(0, 2);
            if (odds == 0)
            {
                attackFeedback = "Catstronaut missed!";
            }
            else
            {
                enemyHp = 0;
            }
        }
        else if (card.id == (int)AllCards.CardTypes.BusinessMan)
        {
            // odds for 50-50
            int odds = Random.Range(0, 2);
            if (odds == 0)
            {
                attackFeedback = "Businessman conviced the rival to join his company!";
                enemyHp = 0;
            }
            else
            {
                attackFeedback =
                    "Businessman failed to convince the rival and it seems squirrel is now annoyed.";
            }
        }
        else
        {
            if (card.damage > 0)
            {
                wasItDamageAttack = true;
            }
            else
            {
                wasItDamageAttack = false;
            }
            enemyHp -= card.damage * (buff == (int)Buffs.DoubleDamage ? 2 : 1);
        }
        float enemyHPFill = enemyHp / 50;

        if (enemyHPFill == 0)
        {
            EnemyHealthBar.sprite = healthBarEmpty;
        }
        else if (enemyHPFill <= 1)
        {
            EnemyHealthBar.sprite = healthBar1_5th;
        }
        else if (enemyHPFill <= 2)
        {
            EnemyHealthBar.sprite = healthBar2_5th;
        }
        else if (enemyHPFill <= 3)
        {
            EnemyHealthBar.sprite = healthBar3_5th;
        }
        else if (enemyHPFill <= 4)
        {
            EnemyHealthBar.sprite = healthBar4_5th;
        }
        else if (enemyHPFill <= 5)
        {
            EnemyHealthBar.sprite = healthBar;
        }

        player.setHealth(player.getHealth() + card.heal);
        textHealth.text = player.getHealth().ToString() + "%";

        buff = -1;
        if (card.id == (int)AllCards.CardTypes.PrincessSailor)
        {
            buff = (int)Buffs.DoubleDamage;
        }

        if (player.getHealth() <= 0)
        {
            loseScene();
        }
        else if (enemyHp <= 0)
        {
            winScene();
        }
        else
        {
            GiveAttackFeedback(attackFeedback);
            isPlayerAttacking = false;
            stage++;
        }
    }

    private void PlayerAttack(SupportCard supportCard)
    {
        if (supportCard.damage > 0)
        {
            wasItDamageAttack = true;
        }
        else
        {
            wasItDamageAttack = false;
        }
        enemyHp -= supportCard.damage * (buff == (int)Buffs.DoubleDamage ? 2 : 1);
        float enemyHPFill = enemyHp / 50f;

        if (enemyHPFill == 0)
        {
            EnemyHealthBar.sprite = healthBarEmpty;
        }
        else if (enemyHPFill <= 1)
        {
            EnemyHealthBar.sprite = healthBar1_5th;
        }
        else if (enemyHPFill <= 2)
        {
            EnemyHealthBar.sprite = healthBar2_5th;
        }
        else if (enemyHPFill <= 3)
        {
            EnemyHealthBar.sprite = healthBar3_5th;
        }
        else if (enemyHPFill <= 4)
        {
            EnemyHealthBar.sprite = healthBar4_5th;
        }
        else if (enemyHPFill <= 5)
        {
            EnemyHealthBar.sprite = healthBar;
        }

        player.setHealth(player.getHealth() + supportCard.heal);
        textHealth.text = player.getHealth().ToString() + "%";

        if (player.getHealth() <= 0)
        {
            loseScene();
        }
        else if (enemyHp <= 0)
        {
            winScene();
        }
        else
        {
            GiveAttackFeedback("Used support card " + supportCard.name);
            isPlayerAttacking = false;
            stage++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = string.Empty;
        player = Player.Instance;

        card1.onClick.AddListener(
            delegate
            {
                if (isPlayerAttacking && !isTyping)
                {
                    PlayerAttack(player.getPlayerCards()[0]);
                }
            }
        );
        card2.onClick.AddListener(
            delegate
            {
                if (isPlayerAttacking && !isTyping)
                {
                    PlayerAttack(player.getPlayerCards()[1]);
                }
            }
        );
        card3.onClick.AddListener(
            delegate
            {
                if (isPlayerAttacking && !isTyping)
                {
                    PlayerAttack(player.getPlayerCards()[2]);
                }
            }
        );
        card4.onClick.AddListener(
            delegate
            {
                if (isPlayerAttacking && !isTyping)
                {
                    PlayerAttack(player.getPlayerCards()[3]);
                }
            }
        );
        supportCard1.onClick.AddListener(
            delegate
            {
                if (isPlayerAttacking && !isTyping)
                {
                    SupportCard supportCard = player.getSupportCards()[0];
                    PlayerAttack(supportCard);
                    supportCard1.gameObject.SetActive(false);
                }
            }
        );

        stage = 0;
        GiveAttackFeedback(0);
    }

    int randomEnemyAttack = 0;

    // Update is called once per frame
    void Update()
    {
        if (stage == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (textDisplay.text.Count() != sentences[lineIndex].Count())
                {
                    StopAllCoroutines();
                    textDisplay.text = sentences[lineIndex];
                    imageAtComplete.enabled = true;
                }
                else
                {
                    stage++;
                }
                isTyping = false;
            }
        }
        else if (stage == 1)
        {
            if (!isEnemyAttacking && !isTyping)
            {
                StopAllCoroutines();
                randomEnemyAttack = Random.Range(0, 4);
                Debug.Log("Random enemy attack: " + randomEnemyAttack);
                StartCoroutine(EnemyAttackMessage(randomEnemyAttack + 1));
            }
        }
        else if (stage == 2)
        {
            if (!isEnemyAttacking && !isTyping)
            {
                StopAllCoroutines();
                StartCoroutine(RandomSquirrelAttack(randomEnemyAttack));
                randomEnemyAttack = Random.Range(0, 4);
            }
        }
        else if (stage == 3)
        {
            if (!isPlayerAttacking && !isTyping)
            {
                StopAllCoroutines();
                StartCoroutine(PlayerAttackMessage());
            }
        }
        else if (stage == 4)
        {
            if (!isPlayerAttacking && !isTyping)
            {
                isPlayerAttacking = true;
            }
        }
        else if (stage == 5)
        {
            if (!isPlayerAttacking && !isTyping)
            {
                if (wasItDamageAttack)
                {
                    StopAllCoroutines();
                    StartCoroutine(BossCurseMessages());
                }
                else
                {
                    stage++;
                }
            }
        }
        else if (stage == 6)
        {
            stage = 1;
        }
    }
}
