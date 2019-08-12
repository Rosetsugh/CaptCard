using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{
    public static bool IsCardOnLeft { get; set; }
    public static bool IsCardOnReallyLeft { get; set; }
    public static bool IsCardOnRight { get; set; }
    public static bool IsCardOnReallyRight { get; set; }
    public static bool IsCardThrownable { get; set; }
    public static bool IsCardThrown { get; set; }
    public static bool LockCard { get; set; }
    private static bool repeatGame;
    public static bool RepeatGame
    {
        get { return repeatGame; }
        set { repeatGame = value; }
    }
    private static bool isGameStarted;
    public static bool IsGameStarted
    {
        get { return isGameStarted; }
        set { isGameStarted = value; }
    }

    public static bool ThrowRight { get; internal set; }
    public static bool ThrowLeft { get; internal set; }
}
