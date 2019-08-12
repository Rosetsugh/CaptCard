using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    [HideInInspector]
    public float pointX;
    [HideInInspector]
    public float pointY;

    [HideInInspector]
    public Vector2 firstTouch;
    [HideInInspector]
    public Vector2 currentTouch;
    [HideInInspector]
    public Vector2 lastTouch;

    [HideInInspector]
    public Vector2 PlayerTouch
    {
        get
        {
            return Input.touches[0].deltaPosition;
        }
    }

}
