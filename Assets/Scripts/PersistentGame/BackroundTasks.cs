using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundTasks : MonoBehaviour
{
    

    public static float EremTimer;
    public static float QuanTimer;
    public static float GwynTimer;

  

    public static bool EremHasTask;
    public static bool QuanHasTask;
    public static bool GwynHasTask;

    public static bool CanCollect;

  
    

    public static float[] RevelationCollection = new float[5];
    public static float[] RevelationMax = new float[5];
    public static bool[] RevelationsActivated = new bool[5];


 
    public static int[] effectVals = new int[5];
    public static int[] effectKeys = new int[5];

    public static bool ImmortalsCanCollect;
    public static bool OdeCanCollect;
    public static bool RaggedCanCollect;

    public static int ImmortalsIndex;
    public static int OdeIndex;
    public static int RaggedIndex;
    // Start is called before the first frame update

    /*
     * One of the main functions of this script is time management.  We keep track of process that have cool downs, or take time to complete.
     * Otherwise, those processes will be destroyed when moving between screens.
     */

    private void Awake()
    {
        
  
        ImmortalsIndex = 1;
        OdeIndex = 0;
        RaggedIndex = 2;
    }
    private void Update()
    {

        TaskQueue();
        RevelationQueue();
    
    }

    /*
     * May no employer ever see how I sorta hard coded this
     */
    private void RevelationQueue()
    {
        if (RevelationsActivated[ImmortalsIndex])
        {
            if (RevelationCollection[ImmortalsIndex] > 0 && !ImmortalsCanCollect)
            {
                RevelationCollection[ImmortalsIndex] -= Time.deltaTime;
            }
            else
            {
                ImmortalsCanCollect = true;
                RevelationCollection[ImmortalsIndex] = RevelationMax[ImmortalsIndex];
            }
        }

        if (RevelationsActivated[OdeIndex])
        {
            if (RevelationCollection[OdeIndex] > 0 && !OdeCanCollect)
            {
                RevelationCollection[OdeIndex] -= Time.deltaTime;
            } else
            {
                OdeCanCollect = true;
                RevelationCollection[OdeIndex] = RevelationMax[OdeIndex];
            }
        }

        if (RevelationsActivated[RaggedIndex])
        {
            if (RevelationCollection[RaggedIndex] > 0 && !RaggedCanCollect)
            {
                RevelationCollection[RaggedIndex] -= Time.deltaTime;
            } else
            {
                RaggedCanCollect = true;
                RevelationCollection[RaggedIndex] = RevelationMax[RaggedIndex];

            }
        }

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
