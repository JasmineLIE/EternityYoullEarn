using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GwynharkRewards : Rewards
{
  
    public static int ebonyYield;
    public static int untransYield;

    
 
   public Gwynhark gwynhark;
   public GwynharkTask task;

    private void Start()
    {
        companionTasks[1] = task;
    }
    private void Update()
    {
        if (BackgroundTasks.GwynHasTask)
        {
          

            if (BackgroundTasks.GwynTimer > 0)
            {
                SetText(gwynhark.comName + " is searching...");
            } else
            {
                CollectRewards();
            }
          
        } 
    }
    public void SetUp(GameObject gwyn)
    {
        gwynhark = gwyn.GetComponent<Gwynhark>();
    }
   
    public void SetUpVals(int fedVal1, int fedVal2)
    {
    int[] yields = gwynhark.GenerateYield(fedVal1, fedVal2);

        ebonyYield = yields[0];
        untransYield = yields[1];

      
     
    }

    public void CollectRewards()
    {
        if (BackgroundTasks.GwynHasTask)
        {
         
            gwynhark.CompleteTask(ebonyYield, untransYield);
            gwynhark.GwynTask.GetComponent<GwynharkTask>().UpdateTexts();
            UpdateText();
            BackgroundTasks.GwynHasTask = false;
            Close();
        }
    
    }

  
}
