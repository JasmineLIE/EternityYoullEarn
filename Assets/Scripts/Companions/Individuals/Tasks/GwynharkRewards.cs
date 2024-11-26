using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GwynharkRewards : MonoBehaviour
{
  
    public static int ebonyYield;
    public static int untransYield;

   public Gwynhark gwynhark;
  

   
    private void Update()
    {

                CollectRewards();
            
          
        
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
         
       
            BackgroundTasks.GwynHasTask = false;
         
        }
    
    }

  
}
