using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;


public class GameManager : MonoBehaviour
{
    [Header("Game Start Style")]
    public GameStartStyle style;

    public Button shortcutButton;

    public Canvas gameCanvas;
    public Canvas logoCanvas;
    public GameObject captainObject;
    public GameObject slidingText;
    public GameObject teamObject;
    public GameObject cardManager;
    public GameObject bgCard;
    public PostProcessingProfile profile;
    bool isLogoDisplayed = false;

    // Use this for initialization
    void Start()
    {
        Button btn = shortcutButton.GetComponent<Button>();

        btn.onClick.AddListener(ChangeStyle);

        Camera.main.orthographic = true;
        captainObject.SetActive(false);
        slidingText.SetActive(false);
        teamObject.SetActive(false);
        profile.vignette.enabled = true;
        var vig = profile.vignette.settings;
        vig.intensity = 0f;
        vig.center.y = 0.4f;
        profile.vignette.settings = vig;
        gameCanvas.gameObject.SetActive(false);
        logoCanvas.gameObject.SetActive(true);
        cardManager.SetActive(false);
        bgCard.SetActive(false);

        CardState.IsGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (style == GameStartStyle.Full)
        {
            if (CardState.IsGameStarted)
            {
                CardState.RepeatGame = false;
                if (!isLogoDisplayed)
                {
                    StartCoroutine(FadeOutLogo());
                }
            }
            else if (!gameCanvas.gameObject.activeSelf)
            {
                if (profile.vignette.settings.intensity < 1.00f)
                {
                    var vignitte = profile.vignette.settings;
                    if (vignitte.intensity <= 0.4f)
                    {
                        vignitte.intensity += 0.003f;
                    }
                    else
                    {
                        vignitte.intensity += 0.00375f;
                        vignitte.center.y -= 0.00375f;
                    }
                    profile.vignette.settings = vignitte;
                }//fadeoutGAMELOGO
                else //open game canvas
                {
                    profile.vignette.enabled = false;
                    logoCanvas.gameObject.SetActive(false);
                    Camera.main.orthographic = false;
                    captainObject.SetActive(true);
                    if (captainObject.activeSelf && captainObject.transform.position.z >= 5.5f)//finish of captain
                    {
                        slidingText.SetActive(true);
                        captainObject.SetActive(false);
                    }
                    if (slidingText.activeSelf && slidingText.transform.position.y >= 16.5f) //finish of starwars text
                    {
                        teamObject.SetActive(true);
                        slidingText.SetActive(false);

                    }
                    if (teamObject.activeSelf && teamObject.transform.position.z >= 5.5f)//finish of team
                    {
                        teamObject.SetActive(false);
                        Camera.main.orthographic = true;
                        gameCanvas.gameObject.SetActive(true);
                        cardManager.gameObject.SetActive(true);
                        bgCard.SetActive(true);
                        GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }
        else if (style == GameStartStyle.Manuel)
        {
            GetComponent<AudioSource>().Stop();
            Camera.main.orthographic = true;
            captainObject.SetActive(false);
            slidingText.SetActive(false);
            teamObject.SetActive(false);
            profile.vignette.enabled = false;
            gameCanvas.gameObject.SetActive(true);
            logoCanvas.gameObject.SetActive(false);
            cardManager.SetActive(true);
            bgCard.SetActive(true);
            isLogoDisplayed = true;
            CardState.IsGameStarted = true;
        }
    }

    public void ChangeStyle()
    {
        style = GameStartStyle.Manuel;
    }

    private IEnumerator FadeOutLogo()
    {
        yield return new WaitForSecondsRealtime(1f);
        isLogoDisplayed = true;
        CardState.IsGameStarted = true;
    }
}
public enum GameStartStyle
{
    Full,
    Manuel
}
