using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Companion : MonoBehaviour
{
    //Data Variables

    public string comName;
    public string[] bio;
    public string[] barks;
   

    public SaveData saveData;
    
    public GameObject player;

    public Investment motivation;
    public Investment psyche;



    public int insightCost;

    


    //For completeting tasks
    public int efficiency;
    public float timeToCompleteTask;
    public int mohRate;
    

    protected int additionalMarksEarned;




    private void Awake()
    {


        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CharacterSetUp(string charName)
    {


        //TODO: Bio
        //not really concerned about saved data for now

        comName = charName;

        //draw from save file companion's levels
        GetCurrentIndex(comName);

        int psyche_r = psyche.GetValues_r(psyche.GetIndex());
        int motivation_r = motivation.GetValues_r(motivation.GetIndex());
       

        //set up current cost of active next investment
        psyche.SetCost(GetPsycheGrowthModel(psyche_r, psyche.GetValues_t()));
        motivation.SetCost(GetMotivationGrowthModel(motivation_r, motivation.GetValues_t()));




        //When the default values change for some companions varies
        //so always call this as a safety net, and then change what needs be with the following lines
        SetDefaultValues();

        if (psyche.GetIndex() >= 1)
        {
            UpdatePsycheEffect();
        }

        if (motivation.GetIndex() >= 1)
        {
            UpdateMotivationEffect();
        }

        string barkPath = comName + "Barks.txt";
        barks = ManageTextFiles.GetAllLines(barkPath);

        string bioPath = comName + "Bio.txt";
        bio = ManageTextFiles.GetAllLines(bioPath);

        string motivationPath = comName + "MotivationFlavour.txt";
        motivation.flavourText = ManageTextFiles.GetAllLines(motivationPath);

        string psychePath = comName + "PsycheFlavour.txt";
        psyche.flavourText = ManageTextFiles.GetAllLines(psychePath);
        
    }

    



    public int GetPsycheGrowthModel(int r, int t)
    {
        return ((1 + (r * 2)) * t);
    }

    public int GetMotivationGrowthModel(int r, int t)
    {
        return (r * t) * t;
    }

    private void GetCurrentIndex(string key)
    {
        int[] companionData = saveData.LoadCompanionData(key);

        psyche.SetIndex(companionData[0]);
        motivation.SetIndex(companionData[1]);

    }



    public virtual bool UpgradePsyche()
    {

        if (player.GetComponent<Player>().GetResource(1) >= psyche.GetCost() && psyche.GetIndex() < psyche.effect.GetLength(0))
        {
          
            //Spend resource required
            player.GetComponent<Player>().SetResource(1, (-1) * psyche.GetCost());
       
            int newIndex = psyche.GetIndex() + 1;
          
            psyche.SetIndex(newIndex);
       

            UpdatePsycheEffect();


            int newCost = GetPsycheGrowthModel(psyche.GetValues_r(newIndex), psyche.GetValues_t());

            //get cost of next investment
            psyche.SetCost(newCost);

            //save
            saveData.SaveCompanionPsyche(comName);
        
            return true;

        }
        else
        {
       
            return false;
        }

    }

    public virtual bool UpgradeMotivation()
    {

        if (player.GetComponent<Player>().GetResource(1) >= motivation.GetCost() && motivation.GetIndex() < motivation.effect.GetLength(0))
        {
            //Spend resource require
           
            player.GetComponent<Player>().SetResource(1, (-1) * motivation.GetCost());

           
            int newIndex = motivation.GetIndex() + 1;
         
            
            motivation.SetIndex(newIndex);
        
            UpdateMotivationEffect();


            int newCost = GetMotivationGrowthModel(motivation.GetValues_r(newIndex), motivation.GetValues_t());
            //get cost of next investment
            motivation.SetCost(newCost);

            //save
            saveData.SaveCompanionMotivation(comName);
          
            return true;

        }
        else
        {
    
            return false;
        }

    }
    // --- Called after leveling up or loading in 
    protected virtual void UpdatePsycheEffect()
    {
        for (int i = 0; i < 3; i++)
        {
            psyche.SetEffect(i, psyche.GetEffectArray(i, psyche.GetIndex()));
        }
       
    }

    protected virtual void UpdateMotivationEffect()
    {
        for (int i = 0; i < 3; i++)
        {
            motivation.SetEffect(i, motivation.GetEffectArray(i , motivation.GetIndex()));
        }
    }

    // ---

    public int GetCurrentPsyche()
    {
        return psyche.GetCost();
    }

    public int GetCurrentMotivation()
    {
        return motivation.GetCost();
    }


   

   
     public virtual void CompleteTask()
    {

        //Rest needs to be completed in children
        //Marks earned
        GenerateMarks();
    
    }

    public void GenerateMarks()
    {
        int numerGen = Random.Range(0, 100);
        if (numerGen <= mohRate)
        {
            int marksEarned = Random.Range(3, 5) + saveData.GetExtraMarksGenerated();
            print("Marks generated! " + marksEarned + " marks.");
            player.GetComponent<Player>().SetResource(1, marksEarned);
        }
        else
        {
            print("Failed to get marks!  The gen number was: " + numerGen);

        }
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



    protected virtual void SetDefaultValues()
    {
        //These values are different based on NPC
        //These values indicate that the NPC has no investments
        //This can be overriden and changed
        efficiency = 0;
        mohRate = 20;
        additionalMarksEarned = 0;


    }

    public int GetAdditionalMarksEarned()
    {

        return additionalMarksEarned;
    }

   
    public void SetGlobalAdditionalMarks(int prevVal, int newVal)
    {
        int result = newVal - prevVal;
     
        saveData.SetExtraMarksGenerated(result);
    }


    public string GetBark()
    {
        int temp = Random.Range(0, barks.Length - 1);
        string bark = barks[temp];
        return bark;

    }
}

