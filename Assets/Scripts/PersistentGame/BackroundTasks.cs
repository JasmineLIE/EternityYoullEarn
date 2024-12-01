using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundTasks : MonoBehaviour
{
    public SaveData saveData;

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

    private int ImmortalsIndex;
    private int OdeIndex;
    private int RaggedIndex;
    // Start is called before the first frame update

    /*
     * One of the main functions of this script is time management.  We keep track of process that have cool downs, or take time to complete.
     * Otherwise, those processes will be destroyed when moving between screens.
     */

    private void Awake()
    {
        DontDestroyOnLoad(this);
        saveData = GetComponent<SaveData>();
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
        //if (RevelationsActivated[ImmortalsIndex])
        //{
        //    if (RevelationCollection[ImmortalsIndex] > 0)
        //    {
        //        RevelationCollection[ImmortalsIndex] -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        int insightGained = saveData.GetInsight() + saveData.GetIncremenetTotal() * effectVals[ImmortalsIndex];
        //        saveData.SaveInsight(insightGained);
        //        RevelationCollection[ImmortalsIndex] = RevelationMax[ImmortalsIndex];
        //    }
        //}

        //if (RevelationsActivated[OdeIndex])
        //{
        //    if (RevelationCollection[OdeIndex] > 0)
        //    {
        //        RevelationCollection[OdeIndex] -= Time.deltaTime;
        //    } else
        //    {
        //        int marksCollected = saveData.GetMarksOfHumanity() + effectVals[OdeIndex];
        //        saveData.SaveMOH(marksCollected);
        //        RevelationCollection[OdeIndex] = RevelationMax[OdeIndex];
        //    }
        //}

        //if (RevelationsActivated[RaggedIndex])
        //{
        //    if (RevelationCollection[RaggedIndex] > 0)
        //    {
        //        RevelationCollection[RaggedIndex] -= Time.deltaTime;
        //    } else
        //    {
        //        int insightGained = saveData.GetInsight() + effectVals[RaggedIndex];
        //        saveData.SaveInsight(insightGained);
        //        RevelationCollection[RaggedIndex] = RevelationMax[RaggedIndex];

        //    }
        //}

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
