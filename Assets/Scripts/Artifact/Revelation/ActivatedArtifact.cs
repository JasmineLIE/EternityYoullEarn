using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ActivatedArtifact : ArtifactCard
{
    public int ID;
    public Image fill;
    public CanvasGroup fillBar;
    public bool hasBackgroundTask;

 
   
    private void Start()
    {
        nameText = GetComponent<TMP_Text>();
        artifactDesc = GameObject.FindGameObjectWithTag("ArtifactDesc");
       
       
    }

    private void Update()
    {
        if (hasBackgroundTask)
        {
            fill.fillAmount = BackgroundTasks.RevelationCollection[ID] / timeEffect;

            
        }
    }
    public void SetUp(string moniker, string name, float time, int[] eKeys, int[] eVals, int indexID, string txt)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        artName = name;
        timeEffect = time;
        effectKeys = eKeys;
        effectValues = eVals;
        ID = indexID;
        textFile = txt;

        nameText.text = moniker;
        button.sprite = GameAssets.Instance.Revelations[indexID];

        if (time <= 0)
        {
            //means we have no time effect

            hasBackgroundTask = false;
            fillBar.alpha = 0;
            fillBar.interactable = false;
            fillBar.blocksRaycasts = false;
        }
        else
        {
            hasBackgroundTask = true;
            //the default state is already there
        }

        if (!BackgroundTasks.RevelationsActivated[ID])
        {
            //first time load;
            BackgroundTasks.RevelationCollection[ID] = timeEffect;
            BackgroundTasks.RevelationMax[ID] = timeEffect;
            BackgroundTasks.effectVals[ID] = effectValues[0];
            BackgroundTasks.effectKeys[ID] = effectKeys[0]; 
            BackgroundTasks.RevelationsActivated[ID] = true;

          
        }
    
    }

    public override void DisplayInfo()
    {
        artifactDesc.GetComponent<ArtifactDescription>().SetDesc(artName, textFile, true, GetEffectText());

    }

  
}
