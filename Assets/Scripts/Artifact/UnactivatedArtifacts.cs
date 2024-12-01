using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnactivatedArtifacts : ArtifactCard
{
    /*
     * This script is used to create Unactivated artifact cards
     */
    // Start is called before the first frame update


    public GameObject revelationsContainer;

    public TMP_Text descriptionText;

    public Image[] costIcons;
    public TMP_Text[] costTexts;
    private int[] costKeys;
    private int[] costValues;
    
   
    private bool[] canRedeem;
    private bool redeemable;

   

    
   

    public GameObject player;
    private void Start()
    {
        revelationsContainer = GameObject.FindGameObjectWithTag("RevelationsContainer");
        artifactDesc = GameObject.FindGameObjectWithTag("ArtifactDesc");
   
    }



    private void Update()
    {
        if (player != null)
        {
            UpdateCard();
        }
    }

    public void SetUp(string name, string desc, int[] tempCostKeys, int[] costs, int[] tempEffectKeys, int[] tempEffect, float time)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nameText.text = name;
        textFile = desc;
        artName = name;
        timeEffect = time;
        costKeys = tempCostKeys;
        costValues = costs;
        effectKeys = tempEffectKeys;
        effectValues = tempEffect;
  

        if (tempCostKeys.Length == 1)
        {
            CostSetUp(0, tempCostKeys[0], costs[0]);
            bool[] temp = new bool[1];
            canRedeem = temp;
            canRedeem[0] = false;
            costIcons[1].color = new Color(0, 0, 0, 0);
            costTexts[1].color = new Color(0, 0, 0, 0);

        } else
        {
            bool[] temp = new bool[2];
            canRedeem = temp;

            for (int i = 0; i  < tempCostKeys.Length; i++)
            {
                CostSetUp(i, tempCostKeys[i], costs[i]);
                canRedeem[i] = false;
                
            }

        }

     
      
        descriptionText.text = GetEffectText();
        UpdateCard();

    }
 
    private void CostSetUp(int index, int key, int cost)
    {
       costIcons[index].sprite = GameAssets.Instance.ResourceIcons[key];
        costTexts[index].text = player.GetComponent<Player>().GetResource(key) + "/" + cost;
      
    }

    private void UpdateCard()
    {
        for (int i = 0; i < costKeys.Length; i++)
        {
            if (player.GetComponent<Player>().GetResource(costKeys[i]) < costValues[i])
            {
                costIcons[i].color = Color.red;
                costTexts[i].color = Color.red;
                CheckEligibility(i, false);
            } else
            {
                costTexts[i].color = Color.white;
                costIcons[i].color = Color.white;   
                CheckEligibility(i, true);
            }
       
            costTexts[i].text = player.GetComponent<Player>().GetResource(costKeys[i]) + "/" + costValues[i];
        }
        
        if (redeemable)
        {
            button.color = new Color(0.5411765f, 0.8525754f, 1, 1);
        } else
        {
            button.color = Color.white;
        }
    }

    //If both bools are true, then the main bool to check if we can redeem an artifact is set to true
    private void CheckEligibility(int key, bool eligible)
    {
        canRedeem[key] = eligible;

        bool flag = true;

        for (int i = 0; i < canRedeem.Length; i++)
        {
            if (canRedeem[i] == false)
            {
                flag = false;
            }
        }
       

        redeemable = flag;
    }
    public void Redeem()
    {
        if (redeemable)
        {
           

            //increment artifacts
            int count = player.GetComponent<Player>().saveData.ActivatedCount + 1;
            player.GetComponent<Player>().saveData.ActivatedCount = count;

            ArtifactInfo temp = player.GetComponent<Player>().saveData.ActivateArtifact(artName);
            revelationsContainer.GetComponent<RevelationsContainer>().AddArtifact(temp);    
            Destroy(gameObject); //get rid of this card
         
        } else
        {
            print("we cannot redeem!");
           
          
        }
    }

   
}
