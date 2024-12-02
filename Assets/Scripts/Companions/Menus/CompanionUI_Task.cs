using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CompanionUI_Task : CompanionUI_Menu_Model
{

    public TMP_Text hintText;
    public TMP_Text insightCost;
    public Image icon;
    public TimerController timeControl;

    public string[] compHints = new string[3];

    private void Start()
    {
        compHints[0] = "Erem is well-versed in the history of this ruined kingdom.  After studying 15 Translateed Texts, they can produce an artifact.";
        compHints[1] = "Gwynhark can embark on expeditions to Crystal Ebonies and Untranslated Texts.  You can select which resource he prioritizes.";
        compHints[2] = "Quan is fluent in ancient Vietnamese.  She can turn Untranslated Texts into Translated Texts.";
    }
 
   
   
  
}
