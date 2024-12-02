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

    public Button dispatchBtn;
    public TimerController timerController;


    protected int fedValues; //the values that will be incremented or decremented and sent to scripts via dispatch
    public int thresh; //the MAX for thresh val
    protected int resourceKey;
    protected float timeToComplete;
    public int insightRequired;

    public TMP_Text fedValText;

    public bool canDispatch;

    public CanvasGroup cg, busyScreen;

    public string compName;

    public GameObject RewardFeebackInstance;
    public GameObject CharSpriteTransform;

    public AudioSource SFX;
    
    private void Start()
    {
        cg= GetComponent<CanvasGroup>();
      
    }

    public virtual void SetUp(int insightCost)
    {
        insightRequired = insightCost;
        SFX = GetComponent<AudioSource>();
       
      
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
    
        CanDispatchCheck();
        CheckTimer();
    }

    /*
     * Will calculate time to complete, open Busy Screen, and subtract insight
     */
    public virtual void Dispatch()
    {
        timeToComplete = ReturnCountdown(CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].timeToCompleteTask,
                                            CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].efficiency);

        timerController.SetTime(timeToComplete, timeToComplete);
        //take insight from player
        CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().SetResource(0, (-1) * insightRequired);

        SFX.clip = GameAssets.Instance.SFX[6];
        SFX.Play();
    } 

    public virtual void Increment()
    {
        //need to check if we also have enough
        if (fedValues < thresh && fedValues < CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(resourceKey))
        {
            fedValues++;
            SFX.clip = GameAssets.Instance.SFX[0];
            SFX.Play();
        } else
        {
            SFX.clip = GameAssets.Instance.SFX[1];
            SFX.Play();
        }
        fedValText.text = fedValues.ToString();

        CanDispatchCheck();


    }

    public virtual void Decrement()
    {
        if (fedValues > 0)
        {

            fedValues--;
            SFX.clip = GameAssets.Instance.SFX[0];
            SFX.Play();
        } else
        {
            SFX.clip = GameAssets.Instance.SFX[1];
            SFX.Play();
        }

        fedValText.text = fedValues.ToString();

        CanDispatchCheck();
    }

    private void UpdateInsightText()
    {


        insightCost.text = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(0) + "/" + insightRequired;
            if (CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(0) 
                >= CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].insightCost)
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

    public virtual void CanDispatchCheck()
    {
        if (CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(0) >= insightRequired)
            canDispatch = fedValues > 0;
        dispatchBtn.interactable = canDispatch;
    }

   
  

    public float ReturnCountdown(float timeToComplete, float efficiency)
    {
        return timeToComplete - (((efficiency / 100) / timeToComplete) * 100);

    }

   
    public virtual void Max()
    {
        if (CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(resourceKey) >= thresh)
        {
            fedValues = thresh;
            SFX.clip = GameAssets.Instance.SFX[0];
            SFX.Play();
        } else
        {
            fedValues = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(resourceKey);
            if (fedValues == 0)
            {
                SFX.clip = GameAssets.Instance.SFX[2];
                SFX.Play();
            }
        }
     
        
        fedValText.text = fedValues.ToString();
        CanDispatchCheck();
    }

    public virtual void UpdateText()
    {
        UpdateInsightText();
     
    }

    public virtual void CheckTimer()
    {
        timeToComplete = ReturnCountdown(CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].timeToCompleteTask,
                                            CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].efficiency);
    }
}
