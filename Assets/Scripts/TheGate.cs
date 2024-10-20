using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheGate : Clickable
{

    private GameObject player;
    private int insightIncrement;
    public GameObject ArtifactManager;

    private void Start()
    {
        ArtifactManager.GetComponent<ArtifactManager>().LoadArtifacts();
    }
    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        insightIncrement = player.GetComponent<Player>().saveData.GetInsightIncrementVal();
      
    }

   
    public override void Clicked()
    {
        player.GetComponent<Player>().SetResource(0, insightIncrement);
    

    }

   
}
