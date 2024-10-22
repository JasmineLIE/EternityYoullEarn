using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GwynharkTask : Task
{

    protected int fedValues2;
    protected int resourceKey2;

    public TMP_Text cbVals;
    public TMP_Text utVals;
    public TMP_Text expedition;


    private int expeditionPoints;
    public Image[] cb_counters = new Image[3];
    public Image[] untransTexts_counters = new Image[3];

    public GameObject gwynhark;
    // Start is called before the first frame update

    public GwynharkRewards summary;
    void Start()
    {
        gwynhark = GameObject.FindGameObjectWithTag("Gwynhark");
     
        resourceKey = 2;
        resourceKey2 = 3;
        expeditionPoints = 3;

      
    
    }

    private void Update()
    {
        expedition.text = "Remaining Expedition Points: " + expeditionPoints;
       if ( !BackgroundTasks.GwynHasTask && expeditionPoints == 0)
        {
            canDispatch = true;
        }

      
    }
    public void ResetValues()
    {
       for (int i = 0; i < cb_counters.Length; i++)
        {
            cb_counters[i].color = Color.black;
            untransTexts_counters[i].color = Color.black;
        }

        expeditionPoints = 3;
        fedValues = 0;
        fedValues2 = 0;
        UpdateCBText();
        UpdateUntransText();
        
    }

    public override void SetUp()
    {
        insightRequired = gwynhark.GetComponent<Gwynhark>().insightCost;
        timeToComplete = ReturnCountdown(gwynhark.GetComponent<Gwynhark>().timeToCompleteTask, gwynhark.GetComponent<Gwynhark>().efficiency);
       
        summary.SetUp(gwynhark);
        //we are not using base.SetUp() because we are not using Fed Values
        if (BackgroundTasks.GwynTimer > 0)
        {
            summary.Open();
            timeToComplete = ReturnCountdown(gwynhark.GetComponent<Gwynhark>().timeToCompleteTask, gwynhark.GetComponent<Gwynhark>().efficiency);
            timerController.SetTime(timeToComplete, BackgroundTasks.GwynTimer);
        }
        else
        {
            summary.Close();
         
        }

        UpdateTexts();
    }

    public override void UpdateTexts()
    {

       base.UpdateTexts();
        ResetValues();
        
    }
    public void CBIncrease()
    {
        if (expeditionPoints > 0 && canDispatch)
        {
            fedValues++;
            
            expeditionPoints--;
            AdjustCBIcons();
            UpdateCBText();
          
        } else
        {
            print("No more expedition points!");
        }
    }

    public void CBDecrease()
    {
        if (fedValues > 0 && canDispatch)
        {
            fedValues--;
            expeditionPoints++;
            AdjustCBIcons();
            UpdateCBText();

        }
        else
        {
            print("We cannot go any lower!");
        }
    }

    public void UntransIncrease()
    {
        if (expeditionPoints > 0 && canDispatch)
        {
            fedValues2++;
            expeditionPoints--;
            AdjustUntransIcons();
            UpdateUntransText();
        }
        else
        {
            print("No more expedition points!");
        }
    }

    public void UntransDecrease()
    {
        if (fedValues2 > 0 && canDispatch)
        {
            fedValues2--;
            expeditionPoints++;
            AdjustUntransIcons();
            UpdateUntransText();
        }
        else
        {
            print("We cannot go any lower!");
        }

    }

    public void Request()
    {
        if (expeditionPoints == 0 && player.GetComponent<Player>().GetResource(0) >= insightRequired && canDispatch)
        {
            player.GetComponent<Player>().SetResource(0, (-1) * insightRequired);
            timeToComplete = ReturnCountdown(gwynhark.GetComponent<Gwynhark>().timeToCompleteTask, gwynhark.GetComponent<Gwynhark>().efficiency);

            summary.Open();
            summary.SetUpVals(fedValues, fedValues2);
         
            timerController.SetTime(timeToComplete, timeToComplete);

            BackgroundTasks.GwynTimer = timeToComplete;
            BackgroundTasks.GwynHasTask = true;

;        
            ResetValues();
            UpdateInsightText();
     

        } else
        {
            print("Unable to dispatch!");
        }
    }
    private void UpdateCBText()
    {
        int temp = fedValues * gwynhark.GetComponent<Gwynhark>().MIN_resources;
        int temp2 = fedValues * gwynhark.GetComponent<Gwynhark>().MAX_resources;
        cbVals.text = "Crystal Ebonies: " + temp + " - " + temp2;

        if (fedValues == 0)
        {
            cbVals.text = "Crystal Ebonies: 0";
        }
    }

    private void UpdateUntransText()
    {
        int temp = fedValues2 * gwynhark.GetComponent<Gwynhark>().MIN_resources;
        int temp2 = fedValues2 * gwynhark.GetComponent<Gwynhark>().MAX_resources;
        utVals.text = "Untranslated Texts: " + temp + " - " + temp2;

        if (fedValues2 == 0)
        {
            utVals.text = "Untranslated Texts: 0";
        }
    }

    private void AdjustCBIcons()
    {

       
       
        for(int i = 0; i < fedValues; i++)
        {
            cb_counters[i].color = Color.white;
        }

        for (int i = fedValues; i < cb_counters.Length; i++)
        {
            cb_counters[i].color = Color.black;
        }
    }

    private void AdjustUntransIcons()
    {
       for (int i = 0; i < fedValues2; i++)
        {
            untransTexts_counters[i].color = Color.white;
        }

       for (int i = fedValues2; i < untransTexts_counters.Length;i++)
        {
            untransTexts_counters[i].color = Color.black;
        }
    }

   

}
