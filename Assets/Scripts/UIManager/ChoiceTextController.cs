using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTextController : MonoBehaviour
{
    public Text choiceText;
    public CardManager cardManager;
    private Color startColor;

    private void Start()
    {
        if (cardManager == null)
            cardManager = GameObject.Find("Card Manager").GetComponent<CardManager>();
        startColor = choiceText.color;
    }

    private void Update()
    {
        GetChoices();
    }

    private void GetChoices()
    {
        if (!CardState.IsCardThrown)
        {
            if (CardState.IsCardOnLeft)
            {
                //choiceText.text = "Choice #1..";
                choiceText.text = cardManager.card.choiceLeft.choice.ToUpper();
                if (CardState.IsCardOnReallyLeft)
                {
                    choiceText.color = startColor;
                }
                else
                {
                    choiceText.color = Color.white;
                }
            }
            else if (CardState.IsCardOnRight)
            {
                //choiceText.text = "Choice #2..";
                choiceText.text = cardManager.card.choiceRight.choice.ToUpper();
                if (CardState.IsCardOnReallyRight)
                {
                    choiceText.color = startColor;
                }
                else
                {
                    choiceText.color = Color.white;
                }
            }
            else choiceText.text = "";
        }
        if (CardState.LockCard)
        {
            choiceText.text = "";
        }
    }
}
