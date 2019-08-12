using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePanelController : MonoBehaviour {

    public RectTransform choicePanel;

	// Use this for initialization
	void Start () {
        choicePanel.offsetMin = new Vector2(0f, 200f);
	}
	
	// Update is called once per frame
	void Update () {
        if ((CardState.IsCardOnLeft || CardState.IsCardOnRight) && !CardState.LockCard)
            choicePanel.offsetMin = new Vector2(0f, 0f);
        else choicePanel.offsetMin = new Vector2(0f, 200f);
	}
}
