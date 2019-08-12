using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public GameObject DB_Cards;

    private KnowledgeDeck knowledge;
    private SafetyDeck safety;
    private MoneyDeck money;
    private PrestigeDeck prestige;

    private void Awake()
    {
        if (DB_Cards != null)
        {
            knowledge = GetComponent<KnowledgeDeck>();
            safety = GetComponent<SafetyDeck>();
            money = GetComponent<MoneyDeck>();
            prestige = GetComponent<PrestigeDeck>();
        }
    }

    public List<CardTemplate> GetKnowledgeDeckOnly()
    {
        var data = knowledge.allCards;
        return data;
    }

    public List<CardTemplate> GetSmallDeck()
    {
        var data = new List<CardTemplate>();

        //take cards from basicKnowledge then put them in a stack
        Stack<CardTemplate> knowledgeStack = new Stack<CardTemplate>();
        foreach (var card in knowledge.basicCards)
            knowledgeStack.Push(card);

        //take cards from basicSafety then put them in a stack
        Stack<CardTemplate> safetyStack = new Stack<CardTemplate>();
        foreach (var card in safety.basicCards)
            safetyStack.Push(card);

        //take cards from basicMoney then put them in a stack
        Stack<CardTemplate> moneyStack = new Stack<CardTemplate>();
        foreach (var card in money.basicCards)
            moneyStack.Push(card);

        //take cards from basicPrestige then put them in a stack
        Stack<CardTemplate> prestigeStack = new Stack<CardTemplate>();
        foreach (var card in prestige.basicCards)
        {
            prestigeStack.Push(card);
        }

        bool[] isDeckEmpty = { false, false, false, false };
        while (true)
        {
            int randomStack = Random.Range(0, 4);
            switch (randomStack)
            {
                case 0:
                    if (knowledgeStack.Count > 0)
                    {
                        data.Add(knowledgeStack.Pop());
                    }
                    else
                    {
                        isDeckEmpty[randomStack] = true;
                    }
                    break;
                case 1:
                    if (safetyStack.Count > 0)
                    {
                        data.Add(safetyStack.Pop());
                    }
                    else
                    {
                        isDeckEmpty[randomStack] = true;
                    }
                    break;
                case 2:
                    if (moneyStack.Count > 0)
                    {
                        data.Add(moneyStack.Pop());
                    }
                    else
                    {
                        isDeckEmpty[randomStack] = true;
                    }
                    break;
                case 3:
                    if (prestigeStack.Count > 0)
                    {
                        data.Add(prestigeStack.Pop());
                    }
                    else
                    {
                        isDeckEmpty[randomStack] = true;
                    }
                    break;
                default:
                    break;
            }
            bool isAllEmpty = true;
            foreach (var empty in isDeckEmpty)
            {
                if (!empty)
                {
                    isAllEmpty = false;
                }
            }
            if (isAllEmpty)
            {
                break;
            }
        }
        return data;
    }
}
