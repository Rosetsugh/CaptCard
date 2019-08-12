using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChildren : MonoBehaviour {
    public static void DisableAllChildrenOf(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }
}
