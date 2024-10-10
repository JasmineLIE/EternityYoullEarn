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
   
    //These hold the 'r' value from the spreadsheet, incrementing each level
    private int[] psycheFactors = new int[4];
    private int[] motivationFactors = new int[4];

    //Represents what investment level the player is currently on
    private int psycheIndex;
    private int motivationIndex; 

    //These values represent the current cost of the invesment
    private int psycheCost;
    private int motivationCost;

    //This value represents 't' from the Spreadsheet
    private int growthFactor_psyche;
    private int growthFactor_motivation;

   
    public void CharacterSetUp(string charName, int[] psycheFact, int[] motivationFact, int psyche_t, int motivation_t)
    {
        growthFactor_motivation = motivation_t;
        growthFactor_psyche = psyche_t;

        for (int i = 0; i < psycheFact.Length; i++)
        {
            psycheFactors[i] = psycheFact[i];
            motivationFactors[i] = motivationFact[i];
        }
        //TODO: Bio
        //not really concerned about saved data for now

        comName = charName;

        //draw from save file companion's level
            GetCurrentIndex(comName);
       
      

      
        //set up current cost of active next investment
      psycheCost = GetPsycheGrowthModel(psycheFactors[psycheIndex], growthFactor_psyche);
      motivationCost = GetMotivationGrowthModel(motivationFactors[motivationIndex], growthFactor_motivation);

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

    public void UpgradePsyche()
    {
        //The function in SaveData increments for us
        saveData.SaveCompanionPsyche(comName);
    }
   
    public void UpgradeMotivation()
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
