using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionUI_General : MonoBehaviour
{
    public static TMP_Text compName;
    public static TMP_Text bark;
    public CanvasGroup menuCG;

    public void Close()
    {
        menuCG.alpha = 0;
        menuCG.interactable = false;
        menuCG.blocksRaycasts = false;
    }

   public static void SetText(string name, string tempBark)
    {
        compName.text = name;
        bark.text = tempBark;   
    }


}
