using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CompanionUI_Task_Quan : Tasks
{
    static int utVals;
    public TMP_Text translationLimit;
    public TMP_Text estimatedVal;
    private void Start()
    {
        compName = "Quan";
        fedValues = 0;

    }

    private void Update()
    {

        //should not be able to alter this course once a task has been dispatched
        if (BackgroundTasks.QuanHasTask && BackgroundTasks.QuanTimer <= 0)
        {

            CompanionUI_Menu.comps[2].GetComponent<Quan>().CompleteTask(utVals);


            BackgroundTasks.QuanHasTask = false;

        }

       
    }

    public override void Decrement()
    {
        base.Decrement();
        estimatedVal.text = CompanionUI_Menu_Model.currComp.GetComponent<Quan>().CalculateRewards(fedValues).ToString();
    }
    public override void Increment()
    {
        thresh = CompanionUI_Menu_Model.currComp.GetComponent<Quan>().MAX_untranslatedTexts;
        estimatedVal.text = CompanionUI_Menu_Model.currComp.GetComponent<Quan>().CalculateRewards(fedValues).ToString();
        base.Increment();

    }

    public override void Dispatch()
    {
        base.Dispatch();
        utVals = fedValues;
        BackgroundTasks.QuanTimer = timeToComplete;
        BackgroundTasks.QuanHasTask = true;
    }

    public override void UpdateTexts()
    {
        base.UpdateTexts();
        translationLimit.text = "Translation Limit: " + CompanionUI_Menu.comps[2].GetComponent<Quan>().MAX_untranslatedTexts;
    }

    public override void CanDispatchCheck()
    {
        if (CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().GetResource(0) >= insightRequired)
            canDispatch = fedValues > 1;
        dispatchBtn.interactable = canDispatch;
    }
}
