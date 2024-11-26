using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class CompanionUI_Task_Erem : Tasks
{
    static int studyVal;
    public DiscoveredPrompt prompt;
    public ArtifactManager artifactManager;
    
    public Image progressBar;
    public TMP_Text artifactCount;
    public TMP_Text studyLimit;
    private void Start()
    {
        compName = "Erem";
    }

    private void Update()
    {
        //should not be able to alter this course once a task has been dispatched
        if (BackgroundTasks.EremHasTask && BackgroundTasks.EremTimer <= 0)
        {

            CompanionUI_Menu.comps[0].GetComponent<Erem>().CompleteTask(studyVal);


            BackgroundTasks.EremHasTask = false;

        }

       
    }

    public override void UpdateTexts()
    {
        base.UpdateTexts();
        studyLimit.text = "Study Limit: " + CompanionUI_Menu.comps[0].GetComponent<Erem>().MAX_translatedTexts;
    }

  
}
