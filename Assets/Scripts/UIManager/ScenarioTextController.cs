using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioTextController : MonoBehaviour {

    public CardManager cardManager;
    public Text scenarioText;

    private void Start()
    {
        if(cardManager == null)
        {
            cardManager = GameObject.Find("Card Manager").GetComponent<CardManager>();
            if(cardManager.card == null)
            {
                scenarioText.text = "Kart bulunamadı";
            }
            else
            {
                scenarioText.text = cardManager.card.scenarioText.ToUpper();
            }
        }
        else
        {
            if (cardManager.card == null)
            {
                Debug.Log("Card yok sadece");
            }
            else
            {
                scenarioText.text = cardManager.card.scenarioText.ToUpper();
            }
        }
    }

    private void LateUpdate()
    {
        if (CardState.IsCardThrown)
            StartCoroutine(UpdateScenario());
    }

    private IEnumerator UpdateScenario()
    {
        yield return new WaitForSeconds(0.8f);
        scenarioText.text = cardManager.card.scenarioText.ToUpper();
    }
}
