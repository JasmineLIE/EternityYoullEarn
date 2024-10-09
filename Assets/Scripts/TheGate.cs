using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheGate : Clickable
{

    private GameObject player;
    private int insightIncrement;
    public TMP_Text insightDisplay;

    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        insightIncrement = player.GetComponent<Player>().saveData.GetInsightIncrementVal();
      
    }

    private void Start()
    {
        insightDisplay.text = "Insight is: " + player.GetComponent<Player>().GetResource(0);
    }
    public override void Clicked()
    {
        player.GetComponent<Player>().SetResource(0, insightIncrement);
        insightDisplay.text = "Insight is: " + player.GetComponent<Player>().GetResource(0);


    }

   
}
