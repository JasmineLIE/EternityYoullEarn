using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{

    //DISPATCH BUTTON
    public Image icon;
    public TMP_Text insightCost;


    protected int fedValues;
    public int thresh;
    protected int resourceKey;
    protected float timeToComplete;
    public int insightRequired;

    public TMP_Text fedValText;

    public bool canDispatch;




    public virtual void Dispatch()
    {
        CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().SetResource(0, (-1) * insightRequired);
        UpdateInsightText();

    }

    public void UpdateInsightText()
    {
        if (CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().GetResource(0) >= CompanionUI_Menu_Model.currComp.insightCost)
        {

            icon.color = new Color(0.227451f, 0.1490196f, 0.08235294f); //brown
            insightCost.color = new Color(0.227451f, 0.1490196f, 0.08235294f);
        }
        else
        {
            icon.color = Color.red;
            insightCost.color = Color.red;
        }
    }

}
