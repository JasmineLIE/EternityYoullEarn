using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

  

    //For choosing/spending resources
    protected int fedValues;
    protected int thresh;
    protected int resourceKey;

    
    //this will turn into "Redeem" for Erem after a certain amount of texts have been researched
    public TMP_Text dispatchText;
    public TMP_Text insightText;
    public TMP_Text fedValText;

    public int insightRequired;

    public GameObject player;

    private void Awake()
    {
        fedValues = 0;
        fedValText.text = fedValues.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
    }
   


    public virtual void Increases()
    {
        if (fedValues < thresh)
        {
            fedValues++;
            fedValText.text = fedValues.ToString();
        }
        else
        {
            print("Cannot increase any more!");
        }
    }

    public virtual void Decreases()
    {
        if (fedValues > 0)
        {
            fedValues--;
            fedValText.text = fedValues.ToString();
        }

        else
        {
            print("Cannot decrease any more!");
        }
    }


    public int RequestTask()
    {
        if (player.GetComponent<Player>().GetResource(0) >= insightRequired && fedValues!= 0 && player.GetComponent<Player>().GetResource(resourceKey) >= fedValues)
        {
            //Task submission, subtract required insight
            player.GetComponent<Player>().SetResource(0, (-1)*insightRequired);
            UpdateInsightText();
            int temp = fedValues;
            fedValues = 0;
            fedValText.text = fedValues.ToString();
            return temp;
        } 
       
        else
        {
            
            return 0;

        }
    }

    protected void UpdateInsightText()
    {
        insightText.text = "Insight: " + player.GetComponent<Player>().GetResource(0) + "/" + insightRequired;
        if (insightRequired > player.GetComponent<Player>().GetResource(0))
        {
            insightText.color = Color.red;
        } else
        {
            insightText.color = Color.black;
        }
    }

   

 
}