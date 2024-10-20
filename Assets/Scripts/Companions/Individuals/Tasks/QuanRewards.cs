using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanRewards : Rewards
{

    public static int value;
   
    public Quan quan;
   
 
    // Update is called once per frame
    void Update()
    {
        if (BackgroundTasks.QuanHasTask)
        {
            if (BackgroundTasks.QuanTimer > 0)
            {
                SetText(quan.comName + " is translating...");
            } else
            {
                CollectRewards();
            }
        }
    }

    public void SetUp(GameObject _quan)
    {
        quan = _quan.GetComponent<Quan>();
    }

    public void SetUpVals(int val)
    {
      
        value = val;
     
    }

    public void CollectRewards()
    {
        if (BackgroundTasks.QuanHasTask)
        {
            quan.GetComponent<Quan>().CompleteTask(value);
            BackgroundTasks.QuanHasTask = false;
            Close();
        }
    }
}
