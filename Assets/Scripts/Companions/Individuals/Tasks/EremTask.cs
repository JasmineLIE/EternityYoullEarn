using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EremTask : Task
{
    public GameObject erem;

    public TMP_Text artifactCountdown;
    public TMP_Text translatedTextsAvail;

    public Button artifactRedeem;


    public ArtifactManager artifactManager;

    private bool canClaim;

    public int currTextsResearched;

    public EremRewards summary;

    public DiscoveredPrompt prompt;
  
    // Start is called before the first frame update
    void Start()
    {
        erem = GameObject.FindGameObjectWithTag("Erem");
       
        resourceKey = 4;
        
    }

    private void Update()
    {
        if (canClaim || BackgroundTasks.EremHasTask)
        {
            canDispatch = false;
        } else
        {
            canDispatch = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            canClaim = true;
            RedeemArtifact();
        }
      
    }
    public override void SetUp()
    {
        insightRequired = erem.GetComponent<Erem>().insightCost;
        thresh = erem.GetComponent<Erem>().MAX_translatedTexts;
        currTextsResearched = erem.GetComponent<Erem>().studiedArtifacts;
 

        summary.SetUp(erem);
        if (BackgroundTasks.EremTimer > 0)
        {
            summary.Open();
            timeToComplete = ReturnCountdown(erem.GetComponent<Erem>().timeToCompleteTask, erem.GetComponent<Erem>().efficiency);
            timerController.SetTime(timeToComplete, BackgroundTasks.EremTimer);
        }
        else
        {
            summary.Close();
        }
        base.SetUp();
        UpdateTexts();
      
    }

  
    public override void Increases()
    {
        if (!canClaim)
        {
            thresh = erem.GetComponent<Erem>().MAX_translatedTexts;
            base.Increases();
        }
     
    }

    public override void Decreases()
    {
        if (!canClaim)
        {
            base.Decreases();
        }
    
    }

    public void UpdateArtifactTarget()
    {
        currTextsResearched = erem.GetComponent<Erem>().studiedArtifacts;
        int target = erem.GetComponent<Erem>().artifactTarget;
 
        artifactCountdown.text = (target - currTextsResearched).ToString(); 

        if (target-currTextsResearched <= 0)
        {
            canClaim = true;
            dispatch.interactable = false;
            artifactRedeem.interactable = true;
           
        } else
        {
            canClaim = false;
            dispatch.interactable = true;
            artifactRedeem.interactable = false;
            
            
        }
    }

    
    public void Request()
    {
        int requestVal = RequestTask();

        if (requestVal == 0)
        {
            print("dont have enough insight or required resources!");
        } else
        {
            timeToComplete = ReturnCountdown(erem.GetComponent<Erem>().timeToCompleteTask, erem.GetComponent<Erem>().efficiency);
            summary.Open();
            summary.SetUpVals(requestVal);

            timerController.SetTime(timeToComplete, timeToComplete);

            BackgroundTasks.EremTimer = timeToComplete;
            BackgroundTasks.EremHasTask = true;


      
          
        }
    }

    public void UpdateAvailableTransTexts()
    {
        translatedTextsAvail.text = "Translated Texts: " + player.GetComponent<Player>().GetResource(4).ToString();
    }

    public void RedeemArtifact()
    {
        if (canClaim)
        {
            erem.GetComponent<Erem>().saveData.SetStudiedArtifactsVal(erem.GetComponent<Erem>().studiedArtifacts * (-1)); //reset back to 0
            erem.GetComponent<Erem>().studiedArtifacts = 0;
           ArtifactInfo temp = artifactManager.DiscoverArtifact();
           
            

            if (temp!=null)
            {
                UpdateArtifactTarget();
                prompt.SetUp(temp.name, temp.desc);

            }
            else
            {

                erem.GetComponent<Erem>().GenerateMarks();
                //TODO -- extra MOH?
            }


        }
    
     
   

    }

    public override void UpdateTexts()
    {
        UpdateArtifactTarget();
        UpdateAvailableTransTexts();
        base.UpdateTexts();
    }

}
