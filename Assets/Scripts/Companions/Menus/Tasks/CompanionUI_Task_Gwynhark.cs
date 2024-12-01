using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CompanionUI_Task_Gwynhark : Tasks
{
    public Image[] EbonCounters = new Image[3];
    public Image[] UntransCounters = new Image[3];
    public TMP_Text[] estimatedYields = new TMP_Text[2];
    public TMP_Text EPRemaining;
    int fedValues2; //untrans
    //fed values = CE
  
    static int ceVals;
    static int utVals;

    public GameObject Gwynhark;

    private void Start()
    {
       
        ResetCounters();
        compName = "Gwynhark";
       
        Gwynhark = GameObject.FindGameObjectWithTag(compName);



    }


    private void Update()
    {
        insightCost.text = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(0)
               + "/" + insightRequired;
        //should not be able to alter this course once a task has been dispatched
        if (BackgroundTasks.GwynHasTask && BackgroundTasks.GwynTimer <= 0)
        {

            int[] yields = Gwynhark.GetComponent<Gwynhark>().CompleteTask(ceVals, utVals);


           if (ceVals >0)
            {
                GameObject increment = Instantiate(RewardFeebackInstance);
                increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" + yields[0];
                increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[2];
                increment.transform.SetParent(CharSpriteTransform.transform);
                increment.transform.position = CharSpriteTransform.transform.position;
            }

           if (utVals >0)
            {
                GameObject increment = Instantiate(RewardFeebackInstance);
                increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" + yields[1];
                increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[3];
                increment.transform.SetParent(CharSpriteTransform.transform);
                increment.transform.position = CharSpriteTransform.transform.position;
            }
            BackgroundTasks.GwynHasTask = false;

        }
        UpdateText();
        
    }

    public override void CheckTimer()
    {
        base.CheckTimer();

        if (BackgroundTasks.GwynHasTask)
        {
            timerController.SetTime(timeToComplete, BackgroundTasks.GwynTimer);
        }
        else
        {
            timerController.SetTime(0, 0);
        }
    }
    public new bool Increment()
    {
        if (thresh > 0)
        {
            thresh--;
            UpdateRemainingPoints();
            print(thresh);
            CanDispatchCheck();
            return true;
        } 
        return false;
    }

    public bool Decrement(int val)
    {
        if (val > 0)
        {
            thresh++;
            UpdateRemainingPoints();
            print(thresh + " " + "hi");
            CanDispatchCheck();
            return true;
        }

        return false;
    }
    public void CEIncrement()
    {
        if (Increment())
        {
            fedValues++;
            UpdateCounters(EbonCounters, fedValues, 0);
        }
       
    }

    public void CEDecrement()
    {
        if (Decrement(fedValues))
        {
            
            fedValues--;
            UpdateCounters(EbonCounters, fedValues, 0);
        }
      
    }
    public void UntransIncrement()
    {
        if (Increment())
        {
           
            fedValues2++;
            UpdateCounters(UntransCounters, fedValues2, 1);
        }
    }

    public void UntransDecrement()
    {
        if (Decrement(fedValues2))
        {
            fedValues2--;
            UpdateCounters(UntransCounters, fedValues2, 1);
        }
    }
    private void UpdateCounters(Image[] counters, int index, int arrayKey)
    {
        
        for(int i = 0; i < counters.Length; i++)
        {
            if (i < index)
            {
                counters[i].color = new Color(0.7568628f, 0.5882353f, 0.3411765f); //gold
            } else
            {
                counters[i].color = new Color(0.227451f, 0.1490196f, 0.08235294f); //brown
            }
        }

        UpdateEstimatedYields(arrayKey, index);
    }

    /*
     * Gen. reset
     */
    private void ResetCounters()
    {
        Image[] counters = EbonCounters.Concat(UntransCounters).ToArray();
        foreach(Image image in counters)
        {
            image.color =  new Color(0.227451f, 0.1490196f, 0.08235294f); //brown
        }

        thresh = 3; //in this case, thresh will represent out expedition points
        fedValues = 0;
        fedValues2 = 0;

        UpdateEstimatedYields(0, 0);
        UpdateEstimatedYields(1, 0);

        UpdateRemainingPoints();

        CanDispatchCheck();
    }

    private void UpdateEstimatedYields(int index, int fedVal)
    {
       
            if(fedVal <= 0)
            {
                estimatedYields[index].text = "0";

            } else
            {
                

                estimatedYields[index].text = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Gwynhark>().MIN_resources 
                + "-" 
                + (CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Gwynhark>().MAX_resources * fedVal);
            }
           
          
            //Get estimate
            
        
    }

    private void UpdateRemainingPoints()
    {
        EPRemaining.text = "Expedition Points Remaining: " + thresh.ToString();
    }

    public override void CanDispatchCheck()
    {
        if (thresh <= 0 && CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().GetResource(0) >= insightRequired) 
            canDispatch = thresh <= 0;
        dispatchBtn.interactable = canDispatch;
       
    }

    public override void Dispatch()
    {
     
        base.Dispatch();
        ceVals = fedValues;
        utVals = fedValues2;
        BackgroundTasks.GwynTimer = timeToComplete;
        BackgroundTasks.GwynHasTask = true;


    }
   
}
