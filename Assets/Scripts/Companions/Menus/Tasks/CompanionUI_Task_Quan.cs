using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CompanionUI_Task_Quan : Tasks
{
    static int utVals;
    public TMP_Text translationLimit;
    public TMP_Text estimatedVal;

    public GameObject Quan;
    private void Start()
    {
        compName = "Quan";
        fedValues = 0;
        Quan = GameObject.FindGameObjectWithTag(compName);
        resourceKey = 3;
     

    }

    private void Update()
    {

        //should not be able to alter this course once a task has been dispatched
        if (BackgroundTasks.QuanHasTask && BackgroundTasks.QuanTimer <= 0)
        {

            Quan.GetComponent<Quan>().CompleteTask(utVals);

            GameObject increment = Instantiate(RewardFeebackInstance);
            increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" +
                                Quan.GetComponent<Quan>().CalculateRewards(utVals);
            increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[4];
            increment.transform.SetParent(CharSpriteTransform.transform);
            increment.transform.position = CharSpriteTransform.transform.position;

            
            BackgroundTasks.QuanHasTask = false;

        }
        UpdateText();
        
      
    }
    public override void CheckTimer()
    {
        base.CheckTimer();
        if (BackgroundTasks.QuanHasTask)
        {
            timerController.SetTime(timeToComplete, BackgroundTasks.QuanTimer);
        }
        else
        {
            timerController.SetTime(0, 0);
        }
    }
    public override void Decrement()
    {
        base.Decrement();
        UpdateEstimatedVal();
       
    }
    public override void Increment()
    {
        thresh = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Quan>().MAX_untranslatedTexts;
      
        base.Increment();
        UpdateEstimatedVal();
    }

    public override void Dispatch()
    {
        base.Dispatch();
        utVals = fedValues;
        BackgroundTasks.QuanTimer = timeToComplete;
        BackgroundTasks.QuanHasTask = true;
    }

   
    public override void CanDispatchCheck()
    {
        if (CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(0) >= insightRequired)
            canDispatch = fedValues > 1;
        dispatchBtn.interactable = canDispatch;
    }

    public override void UpdateText()
    {
        base.UpdateText();
        translationLimit.text = "Translation Limit: " + Quan.GetComponent<Quan>().MAX_untranslatedTexts;
    }

    public void UpdateEstimatedVal()
    {
        
    
        if (CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Quan>().CalculateRewards(fedValues) <= 0)
        {
            estimatedVal.text = "0";
        } else
        {
            estimatedVal.text = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Quan>().CalculateRewards(fedValues).ToString();
        }
    }

    public override void Max()
    {
        thresh = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Quan>().MAX_untranslatedTexts;
        base.Max();
        UpdateEstimatedVal();
    }
}
