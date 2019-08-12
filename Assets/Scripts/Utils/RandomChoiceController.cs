using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChoiceController : MonoBehaviour {
    
    public static SideOfChoice GetSide(int index)
    {
        switch (index)
        {
            case 1:
            case 2:
            case 3:
            case 7:
            case 8:
            case 9:
                return SideOfChoice.Left;
            case 4:
            case 5:
            case 6:
            case 10:
            case 11:
            case 12:
                return SideOfChoice.Right;
            default:
                throw new System.Exception("WARNING : GetSide(param : int->index[not recognized])");
        }
    } 
}
