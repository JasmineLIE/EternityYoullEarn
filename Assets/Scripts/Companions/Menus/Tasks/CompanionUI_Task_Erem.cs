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

    public GameObject Erem;
    private void Start()
    {
        compName = "Erem";
        fedValues = 0;
        resourceKey = 4;
        
        Erem = GameObject.FindGameObjectWithTag(compName);
        UpdateProgressBar();

     

    }

    private void Update()
    {
       
        //should not be able to alter this course once a task has been dispatched
        if (BackgroundTasks.EremHasTask && BackgroundTasks.EremTimer <= 0)
        {

            Erem.GetComponent<Erem>().CompleteTask(studyVal);

            GameObject increment = Instantiate(RewardFeebackInstance);
            increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" + studyVal;
            increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[7];
            increment.transform.SetParent(CharSpriteTransform.transform);
            increment.transform.position = CharSpriteTransform.transform.position;

            UpdateProgressBar();

            BackgroundTasks.EremHasTask = false;

        }

        UpdateText();

    }

    public override void CheckTimer()
    {

        if (BackgroundTasks.EremHasTask)
        {
            timerController.SetTime(timeToComplete, BackgroundTasks.EremTimer);
        }
        else
        {
            timerController.SetTime(0, 0);
        }
    }

    public override void Increment()
    {
        thresh = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Erem>().MAX_translatedTexts;
      
        base.Increment();
     
    }
   

  public void UpdateProgressBar()
    {
        int currProgress = Erem.GetComponent<Erem>().studiedArtifacts;
        int max = Erem.GetComponent<Erem>().artifactTarget;
        
        progressBar.fillAmount = ((float)currProgress) / (float)max;    
        artifactCount.text = Erem.GetComponent<Erem>().studiedArtifacts + "/" + Erem.GetComponent<Erem>().artifactTarget;
    }

    public void RedeemArtifact()
    {
        if (Erem.GetComponent<Erem>().GetComponent<Erem>().ArtifactGoalMet())
        {
            //reset back to 0
            //this is messy KILL MEE NYEEOOOW
            Erem.GetComponent<Erem>().saveData.SetStudiedArtifactsVal(Erem.GetComponent<Erem>().studiedArtifacts * (-1));
            Erem.GetComponent<Erem>().studiedArtifacts = 0;

            ArtifactInfo temp = artifactManager.DiscoverArtifact();

            if (temp != null)
            {
                
                prompt.SetUp(temp.name, temp.desc);

            }
            else
            {
                //Get extra marks if there are no more artifacts to discover
                Erem.GetComponent<Erem>().GetComponent<Erem>().GenerateMarks();
                
            }
        }
    }

    public override void Dispatch()
    {
        base.Dispatch();
        studyVal = fedValues;
        Erem.GetComponent<Erem>().player.GetComponent<Player>().SetResource(4, (-1) * studyVal);
        BackgroundTasks.EremTimer = timeToComplete;
        BackgroundTasks.EremHasTask = true;
    }

    public override void UpdateText()
    {
        base.UpdateText();
        studyLimit.text = "Study Cap: " + Erem.GetComponent<Erem>().MAX_translatedTexts; 
        //OLD: for some reason didn't work in the override
        //IT'S BECAUSE I SET PARENT UPDATE TO PRIVATE, CHAT, AM I STUPID?
        //NVM THAT'S NOT RIGHT EITHER FUUUUU
    }

    public override void Max()
    {
        thresh = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetComponent<Erem>().MAX_translatedTexts;
        base.Max();
   
    }
}
