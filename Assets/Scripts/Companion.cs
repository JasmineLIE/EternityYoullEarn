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
    protected int[,] psycheEffect;
    protected int[,] motivationEffect;

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

  

    protected virtual void UpgradePsyche()
    {
      
       if (player.GetComponent<Player>().GetResource(1) >= psycheCost)
        {
            psycheIndex++;
            UpdatePsycheEffect();

            saveData.SaveCompanionPsyche(comName);
        } else
        {
            //TODO
        }
       
    }
   
    protected virtual void UpgradeMotivation()
    {
        
        if (player.GetComponent<Player>().GetResource(1) >= motivationCost)
        {
            motivationIndex++;
            UpdateMotivationEffect();

            saveData.SaveCompanionMotivation(comName);
        } else
        {
            //TODO
        }
       
    }
    private void UpdatePsycheEffect()
    {
        effect_p_1 = psycheEffect[0, psycheIndex];
        effect_p_2 = psycheEffect[1, psycheIndex];
        effect_p_3 = psycheEffect[2, psycheIndex];
    }

    private void UpdateMotivationEffect()
    {
        effect_m_1 = motivationEffect[0, motivationIndex];
        effect_m_2 = motivationEffect[1, motivationIndex];
        effect_m_3 = motivationEffect[2, motivationIndex];
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
        //TODO
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

  
}
