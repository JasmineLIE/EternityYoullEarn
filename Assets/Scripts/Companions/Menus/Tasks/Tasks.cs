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

    static bool busyScreenOpen;
    private void Start()
    {
        cg= GetComponent<CanvasGroup>();
        busyScreenOpen = false;
    }

    public virtual void SetUp(int insightCost)
    {
        insightRequired = insightCost;
       
      
    }

    private void Update()
    {
     
        UpdateTexts();


        switch (CompanionUI_Menu_Model.currComp.comName)
        {
            case "Erem":
                if (BackgroundTasks.EremTimer <= 0)
                {
                    BusyScreenClose();
                }
                break;

            case "Gwynhark":
                if (BackgroundTasks.GwynTimer <= 0 )
                {
                    BusyScreenClose();
                }
                break;
            case "Quan":
                if (BackgroundTasks.QuanTimer <= 0)
                {
                    BusyScreenClose();
                }
                break;
        }

    }

    public void UpdateBusyScreen()
    {
       
            switch (CompanionUI_Menu_Model.currComp.comName)
            {
                case "Erem":
                    if (BackgroundTasks.EremTimer > 0)
                    {
                        BusyScreenOpen(BackgroundTasks.EremTimer);
                    }
                    break;

                case "Gwynhark":
                    if (BackgroundTasks.GwynTimer > 0)
                    {
                        BusyScreenOpen(BackgroundTasks.GwynTimer);
                    }
                    break;
                case "Quan":
                    if (BackgroundTasks.QuanTimer > 0)
                    {
                        BusyScreenOpen(BackgroundTasks.QuanTimer);
                    }
                    break;
            }
        
      
        
       

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
        UpdateBusyScreen();
    }
    public virtual void Dispatch()
    {
        timeToComplete = ReturnCountdown(CompanionUI_Menu_Model.currComp.timeToCompleteTask, 
                                            CompanionUI_Menu_Model.currComp.efficiency);
        BusyScreenOpen(timeToComplete);
        //take insight from player
        CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().SetResource(0, (-1) * insightRequired);
    

    }

    public virtual void Increment()
    {
        if(fedValues < thresh) fedValues++;
        fedValText.text = fedValues.ToString();

        CanDispatchCheck();

    }

    public virtual void Decrement()
    {
        if(fedValues > 0) fedValues--;

        fedValText.text = fedValues.ToString();

        CanDispatchCheck();
    }

    private void UpdateInsightText()
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

    public virtual void CanDispatchCheck()
    {
        if (CompanionUI_Menu_Model.currComp.player.GetComponent<Player>().GetResource(0) >= insightRequired)
            canDispatch = fedValues > 0;
        dispatchBtn.interactable = canDispatch;
    }

    public void BusyScreenOpen(float timeLeft)
    {
        busyScreenOpen = true;
        busyScreen.alpha = 1;
        busyScreen.interactable = true;
        busyScreen.blocksRaycasts = true;

        timerController.SetTime(timeToComplete, timeLeft);
    }

    public void BusyScreenClose()
    {
        busyScreenOpen = false;
        busyScreen.alpha = 0;
        busyScreen.interactable = false;
        busyScreen.blocksRaycasts = false;
    }

    public float ReturnCountdown(float timeToComplete, float efficiency)
    {
        return timeToComplete - (((efficiency / 100) / timeToComplete) * 100);

    }

    public virtual void UpdateTexts()
    {
        UpdateInsightText();
    }

    public void Max()
    {
        fedValues = thresh;
        fedValText.text = fedValues.ToString();
    }
}
