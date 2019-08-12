using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIMGController : MonoBehaviour
{
    public Transform Radars;
    public Transform Cyclones;
    public List<string> AnimatedExtras;

    public Material GetCharacterMaterial(string character, string extra)
    {
        //Close All Animations
        DisableChildren.DisableAllChildrenOf(Radars);
        DisableChildren.DisableAllChildrenOf(Cyclones);
        if (extra == "EMPTY")
        { //if Character is basic
            return Resources.Load<Material>(character + "/" + character);
        }
        else
        {
            bool isAnim = false;
            foreach (var anim in AnimatedExtras)
            {
                if (extra == anim)
                {
                    isAnim = true;
                }
            } //Check if it is animation
            if (!isAnim)
            {
                return Resources.Load<Material>(character + "/" + extra);
            }
            else
            {
                switch (extra)
                {
                    case "S_Radar_1":
                        var anim = Radars.Find("S_Radar_1").gameObject;
                        anim.SetActive(true);
                        break;
                    case "S_Radar_2":
                        anim = Radars.Find("S_Radar_2").gameObject;
                        anim.SetActive(true);
                        break;
                    case "S_Radar_3":
                        anim = Radars.Find("S_Radar_3").gameObject;
                        anim.SetActive(true);
                        break;
                    case "S_Radar_4":
                        anim = Radars.Find("S_Radar_4").gameObject;
                        anim.SetActive(true);
                        break;
                    case "S_Radar_5":
                        anim = Radars.Find("S_Radar_5").gameObject;
                        anim.SetActive(true);
                        break;
                    case "Cyclone_1":
                        anim = Cyclones.Find("Chief Officer").gameObject;
                        anim.SetActive(true);
                        break;
                    case "Cyclone_2":
                        anim = Cyclones.Find("Officer").gameObject;
                        anim.SetActive(true);
                        break;
                    default:
                        return Resources.Load<Material>("UI/First Captain");
                } //Get Animation

                Material mat = Resources.Load<Material>(character + "/" + character);
                if (mat != null)
                {
                    return mat;
                }
                else return Resources.Load<Material>("UI/First Captain");
            }
        }
    }

}
