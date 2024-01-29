using System.Collections.Generic;

public class AllCards
{
    private static AllCards _instance;

    public static AllCards Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AllCards();
            }
            return _instance;
        }
    }

    public enum SupportCardTypes
    {
        Apple,
        Cheese,
        Goat,
    }

    public enum CardTypes
    {
        PrincessSailor,
        BusinessMan,
        Vampire,
        Wizard,
        NotZombie,
        Spaghetti,
        Catstronaut,
        AngryItalianChef,
    }

    public List<Card> getAllCards()
    {
        List<Card> allCards = new List<Card>
        {
            new Card(
                (int)CardTypes.PrincessSailor,
                "Princess Sailer :3",
                "The power of friendship will save the day!!!",
                "Friendship Beam! Next Attack will deal double damage.",
                "Moral Support",
                "Next attack deals double damage",
                0,
                0
            ),
            new Card(
                (int)CardTypes.BusinessMan,
                "Richard Business, CEO",
                "Introduce your enemy to your very legitimate and legal business that is not a pyramid scheme at all.",
                "Business Attack. Let's negotiate a deal.",
                "Marketing",
                "Convince enemy to join you... if your marketing skills are up to it",
                0,
                0
            ),
            new Card(
                (int)CardTypes.Vampire,
                "Sun-Tanned Vampire",
                "What else did you expect him to do?",
                "Vampire Bite!",
                "Vampire Bite",
                "Deal 50 Damage",
                50,
                0
            ),
            new Card(
                (int)CardTypes.Wizard,
                "Community College Wizard",
                "Look, he's doing his best, okay?",
                "Magic Missile!",
                "First Year Magic Spell",
                "Deal 50 Damage",
                50,
                0
            ),
            new Card(
                (int)CardTypes.NotZombie,
                "Not A Zombie",
                "Attack the enemy by 'not eating their brains'",
                "Num Num Num",
                "Not Eating Brains",
                "Deal 50 Damage",
                50,
                0
            ),
            new Card(
                (int)CardTypes.Spaghetti,
                "Bowl of Spaghetti",
                "Are you really going to eat a party member? I mean, it's a bowl of spaghetti, but still.",
                "That was delicious! You feel stronger!",
                "Eat",
                "Restore 50 HP",
                0,
                50
            ),
            new Card(
                (int)CardTypes.Catstronaut,
                "Catstronaut",
                "Even though this cat is abducting someone with a giant UFO, we can't know for sure that it's an alien.",
                "Meow. Teleport. Meow. Meow.",
                "Abduction",
                "50% chance enemy mysteriously disappears",
                0,
                0
            ),
            new Card(
                (int)CardTypes.AngryItalianChef,
                "Angry Italian Chef",
                "A danger to any nearby vampries.",
                "Slice! Dice! Chop!",
                "Ladle Assault",
                "Deal 50 Damage",
                50,
                0
            ),
        };
        return allCards;
    }

    public List<SupportCard> getSupportCards()
    {
        List<SupportCard> supportCards = new List<SupportCard>
        {
            new SupportCard(
                (int)SupportCardTypes.Apple,
                "Apple Card",
                "Use this to avoid a trip to the doctor.",
                "Restores 50 HP",
                0,
                50
            ),
            new SupportCard(
                (int)SupportCardTypes.Cheese,
                "Cheese Wheel",
                "Don't let your dog see this.",
                "Restores 50 HP",
                0,
                50
            ),
            new SupportCard(
                (int)SupportCardTypes.Goat,
                "Armored Goat",
                "Mess with the goat, get hit with the... steel helmet?",
                "Deals 50 damage",
                50,
                0
            )
        };
        return supportCards;
    }
}

public class Card
{
    public int id;
    public string name;
    public string description;
    public string attack_feeback;
    public string skill_name;
    public string skill_description;
    public int damage;
    public int heal;

    public Card(
        int id,
        string name,
        string description,
        string attack_feeback,
        string skill_name,
        string skill_description,
        int damage,
        int heal
    )
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.attack_feeback = attack_feeback;
        this.skill_description = skill_description;
        this.skill_name = skill_name;
        this.damage = damage;
        this.heal = heal;
    }
}

public class SupportCard
{
    public int id;
    public string name;
    public string description;
    public string skill_description;
    public int damage;
    public int heal;

    public SupportCard(
        int id,
        string name,
        string description,
        string skill_description,
        int damage,
        int heal
    )
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.skill_description = skill_description;
        this.damage = damage;
        this.heal = heal;
    }
}
