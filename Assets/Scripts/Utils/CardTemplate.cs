using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardTemplate : ScriptableObject
{
    public string questionType;

    public int scenarioID;
    public string scenarioText;

    public string characterType;

    public string extraIMGType;

    public Choice choiceLeft;
    public Choice choiceRight;

    //card material taken from getMaterial
    public Material artwork;

    public static CardTemplate CreateInstance()
    {
        var data = CreateInstance<CardTemplate>();
        return data;
    }
}
