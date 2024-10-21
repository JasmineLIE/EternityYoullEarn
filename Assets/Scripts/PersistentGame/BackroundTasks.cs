using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundTasks : MonoBehaviour
{
    public Player player;
    public static float EremTimer;
    public static float QuanTimer;
    public static float GwynTimer;

  

    public static bool EremHasTask;
    public static bool QuanHasTask;
    public static bool GwynHasTask;

    public static bool CanCollect;
   
    // Start is called before the first frame update

    /*
     * One of the main functions of this script is time management.  We keep track of process that have cool downs, or take time to complete.
     * Otherwise, those processes will be destroyed when moving between screens.
     */

 
    private void Update()
    {

        TaskQueue();

    
    }

   private void TaskQueue()
    {
        
        if (EremHasTask)
        {
            if (EremTimer > 0)
            {
              
          
                EremTimer -= Time.deltaTime;
            }
        }

        if(QuanHasTask)
        {
            if (QuanTimer > 0)
            {
             
                
                QuanTimer -= Time.deltaTime;    
            }
        }

        if(GwynHasTask)
        {
            if(GwynTimer > 0)
            {
          
                GwynTimer -= Time.deltaTime;
            } 
        }

        if ((GwynTimer <= 0 && GwynHasTask) || (EremTimer <= 0 && EremHasTask) || (QuanTimer <= 0 && QuanHasTask))
        {
            CanCollect = true;
        } else
        {
            CanCollect = false;
        }
    }
  
    
    

}
