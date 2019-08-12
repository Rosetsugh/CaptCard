using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour {

    [Range(0f, 0.025f)]
    public float ScaleFactor;

    private bool isScaled = false;

    public bool IsScaled
    {
        get { return isScaled; }
        set { isScaled = value; }
    }


    //public CardState cardState;

    public void ScaleCard() //translate card as user swipes
    {
        if (!isScaled)
        {
            transform.localScale += new Vector3(ScaleFactor, ScaleFactor, 0f);
            isScaled = true;
        }
    }

    public void ResetScaleOfCard() //recall card to its deck position
    {
        if (isScaled)
        {
            transform.localScale -= new Vector3(ScaleFactor, ScaleFactor, 0f);
            isScaled = false;
        }
    }
}
