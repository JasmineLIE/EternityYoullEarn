using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EremTask : Task
{
    public GameObject erem;

    public TMP_Text artifactCountdown;
    public TMP_Text translatedTextsAvail;

    private int currTextsResearched;
  
    // Start is called before the first frame update
    void Start()
    {
        erem = GameObject.FindGameObjectWithTag("Erem");
       
        resourceKey = 4;
        
    }

    public void SetUp()
    {
        insightRequired = erem.GetComponent<Erem>().insightCost;
        thresh = erem.GetComponent<Erem>().MAX_translatedTexts;
        UpdateArtifactTarget();
        UpdateAvailableTransTexts();
 
      
    }

    public override void Increases()
    {
        thresh = erem.GetComponent<Erem>().MAX_translatedTexts;
        base.Increases();
    }

    public void UpdateArtifactTarget()
    {
        
        int target = erem.GetComponent<Erem>().artifactTarget;
        artifactCountdown.text = (target - currTextsResearched).ToString(); 
    }

    public void Request()
    {
        int requestVal = RequestTask();

        if (requestVal == 0)
        {
            print("dont have enough insight or required resources!");
        } else
        {

            currTextsResearched += requestVal;
            UpdateArtifactTarget();
            UpdateAvailableTransTexts();
            erem.GetComponent<Erem>().CompleteTask(requestVal);
        }
    }

    public void UpdateAvailableTransTexts()
    {
        translatedTextsAvail.text = "Translated Texts: " + player.GetComponent<Player>().GetResource(4).ToString();
    }
}
