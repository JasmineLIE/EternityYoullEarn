using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuanTask : Task
{
    public GameObject quan;
    public TMP_Text untransText;
    public TMP_Text estimatedRewards;

    private void Start()
    {
        quan = GameObject.FindGameObjectWithTag("Quan");
        resourceKey = 3;
       
    }

    public override void SetUp()
    {
        insightRequired = quan.GetComponent<Quan>().insightCost;
        UpdateEstimatedRewardText();
        base.SetUp();
     
    }

  
    public override void Increases() { 
    
        //in case the thresh increases via investment
        thresh = quan.GetComponent<Quan>().MAX_untranslatedTexts;
        
        base.Increases();
        UpdateEstimatedRewardText();


    }

    public override void Decreases()
    {
        base.Decreases();
        UpdateEstimatedRewardText();
    }



    public void Request()
    {
        int requestVal = RequestTask();

        if (requestVal == 0)
        {
            print("Dont have enough insight or required resources!");
        } else
        {
            quan.GetComponent<Quan>().CompleteTask(requestVal);
            UpdateUntranslatedText();
            UpdateInsightText();
            UpdateEstimatedRewardText();

        }


    }

    private void UpdateUntranslatedText()
    {
        untransText.text = "Untranslated Texts: " + player.GetComponent<Player>().GetResource(3);
    }

   

    private void UpdateEstimatedRewardText()
    {
        int rewards = quan.GetComponent<Quan>().CalculateRewards(fedValues);

        if (quan.GetComponent<Quan>().extraRewardsRate == 100)
        {
            rewards += 1;
        }

            if (rewards == -1 || fedValues == 0)
        {
            rewards = 0;
        }
        estimatedRewards.text = rewards.ToString();

        //In considerationn for extra rewards
        if (quan.GetComponent<Quan>().extraRewardsRate == 50 && fedValues != 0)
        {
            estimatedRewards.text = rewards.ToString() + "-" + (rewards + 1).ToString();
        }
      

     
    }
}
