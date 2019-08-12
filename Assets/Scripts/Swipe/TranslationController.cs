using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{

    [Range(0f, 0.025f)]
    public float TranslationFactor;
    [Range(2, 64)]
    public int ReturnCardInFrames;

    //public CardState cardState;

    public void TranslateCard() //translate card as user swipes
    {
        float translationFactor = TranslationFactor * Input.touches[0].deltaPosition.x;
        if (transform.position.x < 0.4f)
        {
            transform.Translate(translationFactor, 0f, 0f);
        }
        else if (transform.position.x >= 0.4f && transform.position.x < 0.6f)
        {
            transform.Translate(translationFactor / 2f, 0f, 0f);
        }
        else
        {
            transform.Translate(translationFactor / 4f, 0f, 0f);
        }
    }

    public void ResetPositionOfCard() //recall card to its deck position
    {
        float currentPositionX = transform.position.x;

        float translationFactor = -1 * (currentPositionX / ReturnCardInFrames);
        if (currentPositionX > 0.1f || currentPositionX < -0.1f)
        {
            transform.Translate(translationFactor, 0f, 0f);
            //cardState.IsCardOnLeftSide = false;
            //cardState.IsCardOnRightSide = false;
        }
        else
        {
            CardState.IsCardOnLeft = false;
            CardState.IsCardOnRight = false;
        }
    }
}
