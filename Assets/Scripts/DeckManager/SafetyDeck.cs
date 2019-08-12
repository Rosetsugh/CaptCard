using System.Collections.Generic;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
public class SafetyDeck : MonoBehaviour
{
    public GameObject DB_Card;
    [Header("Basic Deck Properties")]
    public int cardsInBasicDeck;
    private int counter = 0;

    //[HideInInspector]
    public List<CardTemplate> basicCards;

    [Header("Basic Deck Randomizer Attributes")]
    public List<string> Topics;
    public List<string> ChosenTopics;

    private void Awake()
    {
        if (DB_Card == null)
        {
            DB_Card = GetComponent<BagController>().DB_Cards;
        }
        FindTopics();
        FillSmallDeck();
        ResetCounter();
    }

    private void Update()
    {
        if (CardState.RepeatGame)
        {
            Debug.Log("Repeat in SafetyDeck");
            FindTopics();
            FillSmallDeck();
            ResetCounter();
        }
    }

    private void FindTopics()
    {
        Google2u.CardSafety cards = DB_Card.GetComponent<CardSafety>();
        Topics = new List<string>();
        //find questionType
        for (int i = 0; i < cards.Rows.Count; i++)
        {
            if (Topics.Count == 0)
            {
                Topics.Add(cards.Rows[i]._Question_Type);
            }
            else
            {
                bool isInTopics = false;
                foreach (var topic in Topics)
                {
                    if (cards.Rows[i]._Question_Type == topic)
                    {
                        isInTopics = true;
                    }
                }
                if (!isInTopics)
                {
                    Topics.Add(cards.Rows[i]._Question_Type);
                }
            }
        }

        ChosenTopics = new List<string>();
    }

    public void FillSmallDeck()
    {
        //create new deck
        basicCards = new List<CardTemplate>();
        while (counter < cardsInBasicDeck)
        {
            //choose a topic randomly
            int randomTopicIndex = Random.Range(0, Topics.Count);

            //if anything hasn't put on ChosenTopics then put first random topic
            if (ChosenTopics.Count == 0)
            {
                CardSafety cardSafety = DB_Card.GetComponent<CardSafety>();
                while (true)
                {
                    int randomCardIndex = Random.Range(0, cardSafety.Rows.Count);
                    //if selected cards qType == chosen topic then add it to list
                    if (cardSafety.Rows[randomCardIndex]._Question_Type == Topics[randomTopicIndex])
                    {
                        basicCards.Add(CreateChosenCardBy(cardSafety, randomCardIndex));
                        ChosenTopics.Add(cardSafety.Rows[randomCardIndex]._Question_Type);
                        counter++;
                        break;
                    }
                }
            }
            else
            {
                bool isChosenTopicInDeck = false;
                foreach (var topic in ChosenTopics)
                {
                    if (topic == Topics[randomTopicIndex])
                        isChosenTopicInDeck = true;
                }
                //if selected topic hasnt selected yet then proceed
                if (!isChosenTopicInDeck)
                {
                    //find a card belongs to that topic
                    CardSafety cardSafety = DB_Card.GetComponent<CardSafety>();
                    while (true)
                    {
                        int randomCardIndex = Random.Range(0, cardSafety.Rows.Count);
                        //if selected cards qType == chosen topic then add it to list
                        if (cardSafety.Rows[randomCardIndex]._Question_Type == Topics[randomTopicIndex])
                        {
                            basicCards.Add(CreateChosenCardBy(cardSafety, randomCardIndex));
                            ChosenTopics.Add(cardSafety.Rows[randomCardIndex]._Question_Type);
                            counter++;
                            break;
                        }
                    }
                }
            }
        }
    }

    public void ResetCounter() { counter = 0; }

    private CardTemplate CreateChosenCardBy(CardSafety cardSheet, int index)
    {
        var data = CardTemplate.CreateInstance();

        data.questionType = cardSheet.Rows[index]._Question_Type;

        data.scenarioID = cardSheet.Rows[index]._Scenario_ID;
        data.scenarioText = cardSheet.Rows[index]._Scenario_Text;

        data.characterType = cardSheet.Rows[index]._Character_Type;
        data.extraIMGType = cardSheet.Rows[index]._Extra_IMG_Type;

        switch (RandomChoiceController.GetSide(cardSheet.Rows[index]._Choice_RNG))
        {
            case SideOfChoice.Left:
                data.choiceLeft = new Choice
                {
                    choice = cardSheet.Rows[index]._CT_Text,
                    stats = new int[4]
                };
                data.choiceLeft.stats[0] = cardSheet.Rows[index]._CT_Knowledge;
                data.choiceLeft.stats[1] = cardSheet.Rows[index]._CT_SS;
                data.choiceLeft.stats[2] = cardSheet.Rows[index]._CT_Money;
                data.choiceLeft.stats[3] = cardSheet.Rows[index]._CT_Prestige;

                data.choiceRight = new Choice
                {
                    choice = cardSheet.Rows[index]._CF_Text,
                    stats = new int[4]
                };
                data.choiceRight.stats[0] = cardSheet.Rows[index]._CF_Knowledge;
                data.choiceRight.stats[1] = cardSheet.Rows[index]._CF_SS;
                data.choiceRight.stats[2] = cardSheet.Rows[index]._CF_Money;
                data.choiceRight.stats[3] = cardSheet.Rows[index]._CF_Prestige;
                break;
            case SideOfChoice.Right:
                data.choiceLeft = new Choice
                {
                    choice = cardSheet.Rows[index]._CF_Text,
                    stats = new int[4]
                };
                data.choiceLeft.stats[0] = cardSheet.Rows[index]._CF_Knowledge;
                data.choiceLeft.stats[1] = cardSheet.Rows[index]._CF_SS;
                data.choiceLeft.stats[2] = cardSheet.Rows[index]._CF_Money;
                data.choiceLeft.stats[3] = cardSheet.Rows[index]._CF_Prestige;

                data.choiceRight = new Choice
                {
                    choice = cardSheet.Rows[index]._CT_Text,
                    stats = new int[4]
                };
                data.choiceRight.stats[0] = cardSheet.Rows[index]._CT_Knowledge;
                data.choiceRight.stats[1] = cardSheet.Rows[index]._CT_SS;
                data.choiceRight.stats[2] = cardSheet.Rows[index]._CT_Money;
                data.choiceRight.stats[3] = cardSheet.Rows[index]._CT_Prestige;

                break;
            default:
                throw new System.Exception("WARNING : \n" +
                    "In MoneyDeck.cs\\CreateChosenCardBy(cardSheet : Google2u.CardMoney, index : int) called following function\n" +
                    " -> RandomChoiceController.cs\\GetSide(index : int) does not return a SideOfChoice type");
        }

        return data;
    }
}
