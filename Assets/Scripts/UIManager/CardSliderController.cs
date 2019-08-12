using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSliderController : MonoBehaviour
{

    public CardManager cardManager;
    public Image imgMask;
    public Color changecolor;
    public Color baseColor;

    private void Start()
    {
        imgMask.fillAmount = 0f;
    }

    private void Update()
    {
        if (!CardState.RepeatGame)
        {
            if (CardState.IsCardThrown)
            {
                StartCoroutine(UpdateSlider());
            }
        }
        else
        {
            Debug.Log("CardSlider Repeated");
            imgMask.fillAmount = 0f;
        }
    }

    private IEnumerator UpdateSlider()
    {
        if (cardManager.card.questionType != "Welcome" &&
            cardManager.card.questionType != "Team")
        {
            imgMask.fillAmount += 1 / (float)cardManager.maxNumber;
            imgMask.color = changecolor;
            yield return new WaitForSeconds(1f);
            imgMask.color = baseColor;
        }
    }
}
