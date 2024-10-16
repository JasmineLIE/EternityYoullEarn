using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EremTask : Task
{
    public GameObject erem;

    public TMP_Text artifactCountdown;
    public TMP_Text translatedTextsAvail;
 

    public ArtifactManager artifactManager;

    private bool canClaim;

    private int currTextsResearched;
  
    // Start is called before the first frame update
    void Start()
    {
        erem = GameObject.FindGameObjectWithTag("Erem");
       
        resourceKey = 4;
        
    }

    private void Update()
    {
        if (!canClaim)
        {
            canDispatch = true;
        } else
        {
            canDispatch = false;
        }
    }
    public override void SetUp()
    {
        insightRequired = erem.GetComponent<Erem>().insightCost;
        thresh = erem.GetComponent<Erem>().MAX_translatedTexts;
        currTextsResearched = erem.GetComponent<Erem>().studiedArtifacts;
        UpdateArtifactTarget();
        UpdateAvailableTransTexts();
        base.SetUp();
      
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
        
        int target = erem.GetComponent<Erem>().artifactTarget;
        artifactCountdown.text = (target - currTextsResearched).ToString(); 

        if (target-currTextsResearched == 0)
        {
            canClaim = true;
            dispatchText.text = "Redeem";
        } else
        {
            canClaim = false;
            dispatchText.text = "Dispatch";
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
            erem.GetComponent<Erem>().CompleteTask(requestVal);
            currTextsResearched = erem.GetComponent<Erem>().studiedArtifacts;

            UpdateArtifactTarget();
            UpdateAvailableTransTexts();
          
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
           bool processed = artifactManager.DiscoverArtifact();

            if (processed)
            {
                UpdateArtifactTarget();
            }
            else
            {
                //TODO -- extra MOH?
            }


        }
    
     


    }
}
