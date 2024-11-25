using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{

    //DISPATCH BUTTON
    public Image icon;
    public TMP_Text insightCost;


    protected int fedValues; //the values that will be incremented or decremented and sent to scripts via dispatch
    public int thresh; //the MAX for thresh val
    protected int resourceKey;
    protected float timeToComplete;
    public int insightRequired;

    public TMP_Text fedValText;

    public bool canDispatch;

    public CanvasGroup cg;

    private void Start()
    {
        cg= GetComponent<CanvasGroup>();    
    }

    public virtual void SetUp(int insightCost, float time)
    {
        insightRequired = insightCost;
        timeToComplete = time;

      
    }

    private void Update()
    {
        UpdateInsightText();
    }

    public void Close()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void Open()
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public virtual void Dispatch()
    {
        CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().SetResource(0, (-1) * insightRequired);
        UpdateInsightText();

    }

    public virtual void Increment()
    {
        if(fedValues < thresh) fedValues++;
        fedValText.text = fedValues.ToString();

    }

    public virtual void Decrement()
    {
        if(fedValues > 0) fedValues--;

        fedValText.text = fedValues.ToString();
    }

    public void UpdateInsightText()
    {
        if(CompanionUI_Menu_Model.currComp != null) //safety first!
        {
            insightCost.text = CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().GetResource(0) 
                + "/" + insightRequired;

      
            if (CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().GetResource(0) 
                >= CompanionUI_Menu_Model.currComp.insightCost)
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

}
