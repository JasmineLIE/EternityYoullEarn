using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

  

    public bool canDispatch;

    //For choosing/spending resources
    protected int fedValues;
    public int thresh;
    protected int resourceKey;
    protected float timeToComplete;

    
    //this will turn into "Redeem" for Erem after a certain amount of texts have been researched
    public TMP_Text dispatchText;
    public TMP_Text insightText;
    public TMP_Text fedValText;

    public Button dispatch;

    public int insightRequired;

    public GameObject player;

    public TimerController timerController;

  

    private void Awake()
    {
      
        player = GameObject.FindGameObjectWithTag("Player");
        canDispatch = true;
    }


    private void Update()
    {
        if (!canDispatch)
        {
            dispatch.interactable = false;
        } else
        {
            dispatch.interactable = true;
        }

    }
    public virtual void Increases()
    {
        if (fedValues < thresh && canDispatch)
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
        if (fedValues > 0 && canDispatch)
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
        if (player.GetComponent<Player>().GetResource(0) >= insightRequired && fedValues!= 0 && player.GetComponent<Player>().GetResource(resourceKey) >= fedValues && canDispatch)
        {
            //Task submission, subtract required insight
            player.GetComponent<Player>().SetResource(0, (-1)*insightRequired);
            UpdateInsightText();
            int temp = fedValues;
            fedValues = 0;
            fedValText.text = fedValues.ToString();
            canDispatch = false;
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

    public virtual void SetUp()
    {
        fedValues = 0;
        fedValText.text = fedValues.ToString();
        UpdateInsightText();
    }
 
    public float ReturnCountdown(float timeToComplete, float efficiency)
    {
        return timeToComplete - (((efficiency / 100) / timeToComplete) * 100);

    }
}
