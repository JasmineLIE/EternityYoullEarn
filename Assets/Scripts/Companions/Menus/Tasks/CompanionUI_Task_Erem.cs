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
        fedValues = 0;
        UpdateProgressBar();
        
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

    public override void Increment()
    {
        base.Increment();
        thresh = CompanionUI_Menu_Model.currComp.GetComponent<Erem>().MAX_translatedTexts;
    }
    public override void UpdateTexts()
    {
        base.UpdateTexts();
        studyLimit.text = "Study Limit: " + CompanionUI_Menu.comps[0].GetComponent<Erem>().MAX_translatedTexts;
    }

  public void UpdateProgressBar()
    {
        progressBar.fillAmount = CompanionUI_Menu.comps[0].GetComponent<Erem>().studiedArtifacts 
            / CompanionUI_Menu.comps[0].GetComponent<Erem>().artifactTarget;
    }

    public void RedeemArtifact()
    {
        if (CompanionUI_Menu.comps[0].GetComponent<Erem>().ArtifactGoalMet())
        {
            //reset back to 0
            //this is messy KILL MEE NYEEOOOW
            CompanionUI_Menu.comps[0].GetComponent<Erem>().saveData.SetStudiedArtifactsVal(CompanionUI_Menu.comps[0].GetComponent<Erem>().studiedArtifacts * (-1)); 
            CompanionUI_Menu.comps[0].GetComponent<Erem>().studiedArtifacts = 0;

            ArtifactInfo temp = artifactManager.DiscoverArtifact();

            if (temp != null)
            {
                
                prompt.SetUp(temp.name, temp.desc);

            }
            else
            {
                //Get extra marks if there are no more artifacts to discover
                CompanionUI_Menu.comps[0].GetComponent<Erem>().GenerateMarks();
                
            }
        }
    }

    public override void Dispatch()
    {
        base.Dispatch();
        studyVal = fedValues;
        BackgroundTasks.EremTimer = timeToComplete;
        BackgroundTasks.EremHasTask = true;
    }
}
