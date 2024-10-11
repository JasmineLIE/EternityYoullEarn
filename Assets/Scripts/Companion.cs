using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Companion : Clickable
{
    //Data Variables
  
    private string comName;
    public string[] barks;
    public SaveData saveData;
    public CompanionUI ui;
    public GameObject player;

    //to keep track of current effect bonuses
    protected int effect_p_1;
    protected int effect_p_2;
    protected int effect_p_3;

    protected int effect_m_1;
    protected int effect_m_2;
    protected int effect_m_3;

    //Represents what investment level the player is currently on
    protected int psycheIndex;
    protected int motivationIndex; 

    //These values represent the current cost of the invesment
    private int psycheCost;
    private int motivationCost;

    //r values
    protected int[] psyche_r;
    protected int[] motivation_r;

    //t values
    protected int psyche_t;
    protected int motivation_t;

    //first array is for changes in efficiency
    //second array is for upgrades specific to the character's talen
    //third array is for boosts to earning MoH
    protected int[,,] psycheEffect;
    protected int[,,] motivationEffect;

    protected string[] psycheEffectDesc;
    protected string[] motivationEffectDesc;

    protected int efficiency;
    protected float timeToCompleteTask;

    private void Awake()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CharacterSetUp(string charName)
    {
        

     
        //TODO: Bio
        //not really concerned about saved data for now

        comName = charName;

        //draw from save file companion's level
            GetCurrentIndex(comName);
       
    

      
        //set up current cost of active next investment
      psycheCost = GetPsycheGrowthModel(psyche_r[psycheIndex], psyche_t);
      motivationCost = GetMotivationGrowthModel(motivation_r[motivationIndex], motivation_t);

        UpdatePsycheEffect();
        UpdateMotivationEffect();

      
    }

    public override void Clicked()
    {
        //REMINDER: Ensure the scene has "ClickDetection" to make this work
    
      
       ui.OpenCompanionUI(comName);
    }

  

    public int GetPsycheGrowthModel(int r, int t)
    {
        return ((1 + (r * 2))*t); 
    }

    public int GetMotivationGrowthModel(int r, int t)
    {
        return (r * t) * t;
    }

    private void GetCurrentIndex(string key)
    {
        int[] companionData = saveData.LoadCompanionData(key);

        psycheIndex = companionData[0];
        motivationIndex = companionData[1];


    }

    public void PsycheUpgradeRequest()
    {

        //if the player has enough marks of humanity
        if (player.GetComponent<Player>().GetResource(1) >= psycheCost)
        {
            UpgradePsyche();
        }
        else
        {
            //notify player that they don't have enough
        }
    }

    public void MotivationUpgradeRequest()
    {
        //if the player has enough marks of humanity
        if (player.GetComponent<Player>().GetResource(1) >= motivationCost)
        {
            UpgradeMotivation();
        }
        else
        {
            //notify player that they don't have enough
        }
    }
    protected virtual void UpgradePsyche()
    {
      

        psycheIndex++;
       
        saveData.SaveCompanionPsyche(comName);
    }
   
    protected virtual void UpgradeMotivation()
    {
        

        motivationIndex++;
        saveData.SaveCompanionMotivation(comName);
    }

    public int GetCurrentPsyche()
    {
        return psycheCost;
    }

    public int GetCurrentMotivation()
    {
        return motivationCost;  
    }

  
   public IEnumerator StartTask()
    {
        float countdown = timeToCompleteTask - (((efficiency / 100)/timeToCompleteTask)*100); //Calculate time it takes to complete the task, considering character's efficiency
        yield return new WaitForSeconds(countdown);
        CompleteTask();

    }

    public virtual void CompleteTask()
    {
        //MUST BE WRITTEN IN CHILD
    }

    public virtual string GetPsycheEffectDesc() 
    {
        string placeholder = "";
        return placeholder;
    }

    public virtual string GetMotivationEffectDesc()
    {
        string placeholder = "";
        return placeholder;

    }

   public void UpdatePsycheEffect()
    {
        effect_p_1 = psycheEffect[psycheIndex, 0, 0];
        effect_p_2 = psycheEffect[psycheIndex, 1, 1];
        effect_p_3 = psycheEffect[psycheIndex, 2, 2];
    }

    public void UpdateMotivationEffect()
    {
        effect_m_1 = motivationEffect[motivationIndex, 0, 0];
        effect_m_2 = motivationEffect[motivationIndex, 1, 1];
        effect_m_3 = motivationEffect[motivationIndex, 2, 2];
    }
}
