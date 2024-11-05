using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnactivatedArtifacts : MonoBehaviour
{
    /*
     * This script is used to create Unactivated artifact cards
     */
    // Start is called before the first frame update

   

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image[] costIcons;
    public TMP_Text[] costTexts;
    private int[] costKeys;
    private int[] costValues;
    private int[] effectKeys;
    private int[] effectValues;
    private float timeEffect;
    private bool[] canRedeem;
    private bool redeemable;

    private string textFile;
    public string artName;

    public Image button;
   

    public GameObject player;
   
  
    

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

        string description = ManageTextFiles.GetLineAtKey("[EFFECT]", desc);
        description = ManageTextFiles.ReplaceText(description, effectValues[0].ToString(), "#");

        if (timeEffect > 0)
        {
            description = ManageTextFiles.ReplaceText(description, timeEffect.ToString(), "@");
        }
      
        descriptionText.text = description;
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

    //DEBUG THIS LATER?
    private void CheckEligibility(int key, bool eligible)
    {
        canRedeem[key] = eligible;

        bool flag = true;
        int counter = 0;
        while (flag && counter < canRedeem.Length)
        {
            if (canRedeem[counter] == false)
            {
                flag = false;
            }
            counter++;
        }

        redeemable = flag;
    }
    public void Redeem()
    {
        if (redeemable)
        {

        } else
        {
            print("we cannot redeem!");
        }
    }

    public void DisplayInfo()
    {
        //ArtifactDescription.SendSignal(artName, textFile);
    }

    public void ClearInfo()
    {
        //ArtifactDescription.Clear();
    }
}
