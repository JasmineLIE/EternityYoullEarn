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
   

    public GameObject player;
   
  
    

    private void Update()
    {
        if (player != null)
        {
            UpdateCard();
        }
    }

    public void SetUp(string name, string desc, int[] tempCostKeys, int[] costs, int[] tempEffectKeys, int[] tempEffect)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nameText.text = name;
        descriptionText.text = desc;
        costKeys = tempCostKeys;
        costValues = costs;
        effectKeys = tempEffectKeys;
        effectValues = tempEffect;

        if (tempCostKeys.Length == 1)
        {
            CostSetUp(tempCostKeys[0], costs[0]);
        } else
        {
            for (int i = 0; i  < tempCostKeys.Length; i++)
            {
                costIcons[i].sprite = GameAssets.Instance.ResourceIcons[tempCostKeys[i]];
                costTexts[i].text = player.GetComponent<Player>().GetResource(tempCostKeys[i]) + "/" + costs[i];
                
                
            }
        }

    }
 
    private void CostSetUp(int key, int cost)
    {
       costIcons[0].sprite = GameAssets.Instance.ResourceIcons[key];
        costIcons[1].color = new Color(0, 0, 0, 0);
        costTexts[0].text = player.GetComponent<Player>().GetResource(key) + "/" + cost;
        costTexts[1].color = new Color(0, 0, 0, 0);
   
    }

    private void UpdateCard()
    {
        for (int i = 0; i < costKeys.Length; i++)
        {
            if (player.GetComponent<Player>().GetResource(costKeys[i]) < costValues[i])
            {
                costIcons[i].color = Color.red;
                costTexts[i].color = Color.red;
            } else
            {
                costTexts[i].color = Color.black;
                costIcons[i].color = Color.black;   
            }
       
            costTexts[i].text = player.GetComponent<Player>().GetResource(costKeys[i]) + "/" + costValues[i];
        }
    }

}
