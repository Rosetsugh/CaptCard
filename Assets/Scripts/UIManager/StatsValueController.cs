using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsValueController : MonoBehaviour
{
    public int DefaultValuesOnStart = 0;
    public Text[] statValues;
    public Image[] imgMasks;

    bool IsInCoroutine = false;
    public CardManager cardManager;

    private void Start()
    {
        for (int i = 0; i < statValues.Length; i++)
        {
            statValues[i].text = DefaultValuesOnStart.ToString();
        }
        if (cardManager == null)
        {
            cardManager = GameObject.Find("Card Manager").GetComponent<CardManager>();
        }
        for(int i = 0; i < imgMasks.Length; i++)
        {
            imgMasks[i].fillAmount = 0.5f;
        }
    }

    private void Update()
    {
        if (CardState.RepeatGame)
        {
            Debug.Log("Stats Repeated");
            for (int i = 0; i < statValues.Length; i++)
            {
                statValues[i].text = DefaultValuesOnStart.ToString();
            }
            for (int i = 0; i < imgMasks.Length; i++)
            {
                imgMasks[i].fillAmount = 0.5f;
            }
        }
        if (cardManager.GetComponentInChildren<RotationController>().transform.eulerAngles.z < 60 &&
            cardManager.GetComponentInChildren<RotationController>().transform.eulerAngles.z > 1 &&
            CardState.IsCardThrown)
        {

            if (IsInCoroutine == false)
            {
                StartCoroutine(GetChoiceLeftStats());
            }
        }
        else if (cardManager.GetComponentInChildren<RotationController>().transform.eulerAngles.z > 300 &&
            CardState.IsCardThrown)
        {

            if (IsInCoroutine == false)
            {
                StartCoroutine(GetChoiceRightStats());
            }
        }
        else
        {
            IsInCoroutine = false;
        }
    }

    private IEnumerator GetChoiceRightStats()
    {

        IsInCoroutine = true;

        for (int i = 0; i < statValues.Length; i++)
        {
            statValues[i].color = System.Convert.ToInt32(cardManager.card.choiceRight.stats[i]) > 0 ? Color.green :
                System.Convert.ToInt32(cardManager.card.choiceRight.stats[i]) == 0 ? Color.grey : Color.red;
            int newStat = System.Convert.ToInt32(statValues[i].text);
            newStat += cardManager.card.choiceRight.stats[i];
            statValues[i].text = newStat.ToString();
            imgMasks[i].fillAmount += CalculateStatToIMG(cardManager.card.choiceRight.stats[i]);
        }
        yield return new WaitForSeconds(1.5f);

        foreach (var text in statValues)
            text.color = Color.white;
    }

    private IEnumerator GetChoiceLeftStats()
    {

        IsInCoroutine = true;

        for (int i = 0; i < statValues.Length; i++)
        {
            statValues[i].color = System.Convert.ToInt32(cardManager.card.choiceLeft.stats[i]) > 0 ? Color.green :
                System.Convert.ToInt32(cardManager.card.choiceLeft.stats[i]) == 0 ? Color.grey : Color.red;
            int newStat = System.Convert.ToInt32(statValues[i].text);
            newStat += cardManager.card.choiceLeft.stats[i];
            statValues[i].text = newStat.ToString();
            imgMasks[i].fillAmount += CalculateStatToIMG(cardManager.card.choiceLeft.stats[i]);
        }
        yield return new WaitForSeconds(1.5f);

        foreach (var text in statValues)
            text.color = Color.white;
    }

    private float CalculateStatToIMG(int stat)
    {
        return stat / 100f;
    }
}
