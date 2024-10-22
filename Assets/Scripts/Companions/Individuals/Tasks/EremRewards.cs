using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EremRewards : Rewards
{

    public static int textsRead;
    public Erem erem;
    public EremTask task;


    // Start is called before the first frame update
    void Start()
    {
        companionTasks[2] = task;
    }

    // Update is called once per frame
    void Update()
    {
        if (BackgroundTasks.EremHasTask)
        {
            if (BackgroundTasks.EremTimer > 0)
            {
                SetText(erem.comName + " is reading...");
            }
            else
            {
                CollectRewards();
            }
        }
    }

    public void SetUp(GameObject _erem)
    {
        erem = _erem.GetComponent<Erem>();
    }

    public void SetUpVals(int temp)
    {
        textsRead = temp;
    }
    public void CollectRewards()
    {
        if (BackgroundTasks.EremHasTask)
        {
            erem.CompleteTask(textsRead);
            erem.studiedArtifacts = erem.saveData.GetStudiedArtifactsVal();
            UpdateText();

            BackgroundTasks.EremHasTask = false;
            Close();
        }
    }
}
