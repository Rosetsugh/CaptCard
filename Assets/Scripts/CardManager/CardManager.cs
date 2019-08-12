using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Animator anim;
    public BagController bag;
    private List<CardTemplate> cardDeck;
    public int GetDeckCount() { return cardDeck.Count; }
    public CardTemplate card;
    public Renderer render;
    public DeckType deckType;
    public CardTemplate welcome;
    public CardTemplate ourTeam;
    public CardTemplate endGame;

    public int maxNumber;
    private int index = 0;
    public int GetIndex() { return index; }
    public int Index
    {
        get
        {
            if (index <= (cardDeck.Count - 1))
            {
                return index++;
            }
            else
            {
                index = 0;
                return index;
            }
        }
    }
    public CardTemplate NextCard
    {
        get
        {
            if (index < maxNumber)
            {
                return cardDeck[Index];
            }
            else
            {
                anim.SetTrigger("IsEndedTrigger");
                return endGame;
            }
        }
    }

    void PrepareUniqueCards()
    {
        welcome.choiceRight = new Choice
        {
            choice = "Exciting!",
            stats = new int[4]
        };
        for (int i = 0; i < welcome.choiceRight.stats.Length; i++)
        {
            welcome.choiceRight.stats[i] = 0;
        }
        welcome.choiceLeft = new Choice
        {
            choice = "Let's Play!",
            stats = new int[4]
        };
        for (int i = 0; i < welcome.choiceLeft.stats.Length; i++)
        {
            welcome.choiceLeft.stats[i] = 0;
        }

        ourTeam.choiceRight = new Choice
        {
            choice = "Wait for orders!",
            stats = new int[4]
        };
        for (int i = 0; i < ourTeam.choiceRight.stats.Length; i++)
        {
            ourTeam.choiceRight.stats[i] = 0;
        }
        ourTeam.choiceLeft = new Choice
        {
            choice = "Look Sharp!",
            stats = new int[4]
        };
        for (int i = 0; i < ourTeam.choiceLeft.stats.Length; i++)
        {
            ourTeam.choiceLeft.stats[i] = 0;
        }

        endGame.choiceRight = new Choice
        {
            choice = "I want more..",
            stats = new int[4]
        };
        for (int i = 0; i < endGame.choiceRight.stats.Length; i++)
        {
            endGame.choiceRight.stats[i] = 0;
        }
        endGame.choiceLeft = new Choice
        {
            choice = "Exit",
            stats = new int[4]
        };
        for (int i = 0; i < endGame.choiceLeft.stats.Length; i++)
        {
            endGame.choiceLeft.stats[i] = 0;
        }
    }

    // Use this for initialization
    void Awake()
    {
        GetDeck();
        card = CardTemplate.CreateInstance();
        PrepareUniqueCards();
        card = welcome;
        render.material = GetComponent<CardIMGController>().GetCharacterMaterial(card.characterType, card.extraIMGType);
    }

    private void GetDeck()
    {
        switch (deckType)
        {
            case DeckType.SmallDeck:
                cardDeck = bag.GetSmallDeck();
                    //new List<CardTemplate>();
                break;
            /*case DeckType.MediumDeck:
                break;
            case DeckType.LargeDeck:
                break;*/
            case DeckType.KnowledgeOnly:
                cardDeck = //bag.GetKnowledgeDeckOnly();
                    new List<CardTemplate>();
                break;
            /*case DeckType.SafetyOnly:
                break;
            case DeckType.MoneyOnly:
                break;
            case DeckType.PrestigeOnly:
                break;*/
            default:
                break;
        }
    }

    bool callOnceThrowCard = false;
    bool callOnceNextCard = false;
    // Update is called once per frame
    void Update()
    {
        if (CardState.IsCardThrownable && !callOnceThrowCard)
        {
            callOnceThrowCard = true;
            StartCoroutine(ThrowCard());
        }
        if (CardState.IsCardThrown && !callOnceNextCard)
        {
            callOnceNextCard = true;
            if (card.choiceLeft.choice == endGame.choiceLeft.choice && CardState.ThrowLeft)
            {
                Debug.Log("Exit");
                Application.Quit();
            }
            if (card.choiceRight.choice == endGame.choiceRight.choice && CardState.ThrowRight)
            {
                Debug.Log("Repeat Game");
                CardState.RepeatGame = true;
                GetDeck();
                index = 0;
            }
            CallNextCard();
        }
    }

    private IEnumerator ThrowCard()
    {
        if (card.questionType == "EndGame")
        {
            anim.SetTrigger("IsStartedTrigger");
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(0.5f);

        CardState.IsCardThrownable = false;
        CardState.IsCardThrown = true;
        callOnceNextCard = false;
    }

    private void CallNextCard()
    {
        //callOnce = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        transform.position = Vector3.zero;
        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        GetComponentInChildren<TranslationController>().transform.position = Vector3.zero;
        GetComponentInChildren<TranslationController>().transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        GetComponentInChildren<RotationController>().transform.position = Vector3.zero;
        GetComponentInChildren<RotationController>().transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        GetComponentInChildren<ScaleController>().transform.position = Vector3.zero;
        GetComponentInChildren<ScaleController>().transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        GetComponentInChildren<ScaleController>().transform.localScale = Vector3.one;

        GetComponent<Animator>().Play("TurnCard");

        if (card.questionType == "Welcome")
        {
            Debug.Log("Girdi welcome");
            card = ourTeam;
            render.material = GetComponent<CardIMGController>().GetCharacterMaterial(card.characterType, card.extraIMGType);
            Invoke("UnlockCard", 1f);
            CardState.IsCardThrown = false;
        }
        else
        {
            Debug.Log("Girdi normal");
            card = NextCard;
            render.material = GetComponent<CardIMGController>().GetCharacterMaterial(card.characterType, card.extraIMGType);
            Invoke("UnlockCard", 1f);
            CardState.IsCardThrown = false;
        }
    }

    private void UnlockCard()
    {
        CardState.RepeatGame = false;
        CardState.LockCard = false;
        callOnceThrowCard = false;
        callOnceNextCard = false;
    }
}
public enum DeckType
{
    SmallDeck,
    //MediumDeck,
    //LargeDeck,
    KnowledgeOnly,
    //SafetyOnly,
    //MoneyOnly,
    //PrestigeOnly
}