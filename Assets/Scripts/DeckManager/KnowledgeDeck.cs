using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
public class KnowledgeDeck : MonoBehaviour
{
    public GameObject DB_Card;
    [Header("Basic Deck Properties")]
    public int cardsInBasicDeck;
    private int counter = 0;

    //[HideInInspector]
    public List<CardTemplate> basicCards;
    public List<CardTemplate> allCards;

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
        GetAllCards();
        ResetCounter();
    }

    private void Update()
    {
        if (CardState.RepeatGame)
        {
            Debug.Log("Repeat in KnowledgeDeck");
            FindTopics();
            FillSmallDeck();
            GetAllCards();
            ResetCounter();
        }
    }

    private void GetAllCards()
    {
        List<int> chosenIndexes = new List<int>();
        allCards = new List<CardTemplate>();
        CardKnowledge knowledge = DB_Card.GetComponent<CardKnowledge>();
        for (int i = 0; i < knowledge.Rows.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, knowledge.Rows.Count);
            if (allCards.Count == 0)
            {
                allCards.Add(CreateChosenCardBy(knowledge, randomIndex));
                chosenIndexes.Add(randomIndex);
            }
            else
            {
                bool inDeck = false;
                foreach (var chosenIndex in chosenIndexes)
                {
                    if (chosenIndex == randomIndex)
                    {
                        inDeck = true;
                    }
                }
                if (!inDeck)
                {
                    allCards.Add(CreateChosenCardBy(knowledge, randomIndex));
                    chosenIndexes.Add(randomIndex);
                }
                else
                {
                    i--;
                }
            }
        }
    }

    private void FindTopics()
    {
        CardKnowledge cards = DB_Card.GetComponent<CardKnowledge>();
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
            int randomTopicIndex = UnityEngine.Random.Range(0, Topics.Count);

            //if anything hasn't put on ChosenTopics then put first random topic
            if (ChosenTopics.Count == 0)
            {
                CardKnowledge cardKnowledge = DB_Card.GetComponent<CardKnowledge>();
                while (true)
                {
                    int randomCardIndex = UnityEngine.Random.Range(0, cardKnowledge.Rows.Count);
                    //if selected cards qType == chosen topic then add it to list
                    if (cardKnowledge.Rows[randomCardIndex]._Question_Type == Topics[randomTopicIndex])
                    {
                        basicCards.Add(CreateChosenCardBy(cardKnowledge, randomCardIndex));
                        ChosenTopics.Add(cardKnowledge.Rows[randomCardIndex]._Question_Type);
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
                    CardKnowledge cardKnowledge = DB_Card.GetComponent<CardKnowledge>();
                    while (true)
                    {
                        int randomCardIndex = UnityEngine.Random.Range(0, cardKnowledge.Rows.Count);
                        //if selected cards qType == chosen topic then add it to list
                        if (cardKnowledge.Rows[randomCardIndex]._Question_Type == Topics[randomTopicIndex])
                        {
                            basicCards.Add(CreateChosenCardBy(cardKnowledge, randomCardIndex));
                            ChosenTopics.Add(cardKnowledge.Rows[randomCardIndex]._Question_Type);
                            counter++;
                            break;
                        }
                    }
                }
            }
        }
    } //Completed

    public void ResetCounter() { counter = 0; }

    private CardTemplate CreateChosenCardBy(CardKnowledge cardSheet, int index)
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
