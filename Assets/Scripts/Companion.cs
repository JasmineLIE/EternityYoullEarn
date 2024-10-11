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
  


    //Represents what investment level the player is currently on
    private int psycheIndex;
    private int motivationIndex; 

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

        print("The current psyche cost for " + comName + " is " + psycheCost);

    }

    public override void Clicked()
    {
        //REMINDER: Ensure the scene has "ClickDetection" to make this work
        print("You are clicking " + comName);
      
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

    public virtual void UpgradePsyche()
    {
        //The function in SaveData increments for us
        saveData.SaveCompanionPsyche(comName);
    }
   
    public virtual void UpgradeMotivation()
    {
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
 }
