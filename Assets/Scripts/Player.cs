using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private int insight;
    private int marksOfHumanity;
    private int crystalEbonies;
    private int textsUntrans;
    private int textsTrans;

    public SaveData saveData;
    public TMP_Text[] resource = new TMP_Text[5];


    private void Update()
    {
        //Watch for passive resources
        if(BackgroundTasks.ImmortalsCanCollect)
        {
            int insightGained = (saveData.GetIncremenetTotal() * BackgroundTasks.effectVals[BackgroundTasks.ImmortalsIndex]);
            SetResource(BackgroundTasks.effectKeys[BackgroundTasks.ImmortalsIndex], insightGained);
            BackgroundTasks.ImmortalsCanCollect = false;    
        }

        if (BackgroundTasks.OdeCanCollect)
        {
            int markscollected =  BackgroundTasks.effectVals[BackgroundTasks.OdeIndex];
            SetResource(BackgroundTasks.effectKeys[BackgroundTasks.OdeIndex], markscollected);
            BackgroundTasks.OdeCanCollect = false;
        }

        if (BackgroundTasks.RaggedCanCollect)
        {
            int insightGained = BackgroundTasks.effectVals[BackgroundTasks.RaggedIndex];
          
            SetResource(BackgroundTasks.effectKeys[BackgroundTasks.RaggedIndex], insightGained);
            BackgroundTasks.RaggedCanCollect = false;   
        }

    }
    private void Start()
    {

    
        //will load player data every time the scene changes
        int[] loadedPlayerData = saveData.LoadPlayerData();

        //Load the data retrieved from the json file into the local variables of player
        //everything should start at 0 when game is booted
       for (int i = 0; i < loadedPlayerData.Length; i++)
        {
        
            SetResource(i, loadedPlayerData[i]);
            
         
        }
          
    }
       
    public void SetResource(int key, int val)
    {
   
        /**
         * (Referenced like array)
         * Insight = 0
         * Marks of Humanity = 1
         * Crystal Ebonies = 2
         * Untranslated Texts = 3
         * Translated Texts = 4
         */

      // log(n) time complexity :weary:
    
       if (key == 2)
        {
            crystalEbonies += val;
            saveData.SaveCrystalEbonies(crystalEbonies);
        } 
        else if (key < 2)
        {
            if (key == 1)
            {
                marksOfHumanity += val;
                saveData.SaveMOH(marksOfHumanity);
            } 
            else
            {
                insight += val;
                saveData.SaveInsight(insight);
            }
        } 
        else
        {
            if (key == 3)
            {
                textsUntrans += val;
                saveData.SaveUntransTexts(textsUntrans);
            } 
            else
            {
                textsTrans += val;
                saveData.SaveTransTexts(textsTrans);
            }
        }
        resource[key].text = GetResource(key).ToString();
    }

    public int GetResource(int key)
    {
        /**
         * (Referenced like array)
         * Insight = 0
         * Marks of Humanity = 1
         * Crystal Ebonies = 2
         * Untranslated Texts = 3
         * Translated Texts = 4
         */

        if (key == 2)
        {
            return crystalEbonies;
        }
        else if (key < 2)
        {
            if (key == 1)
            {
                return marksOfHumanity;
            }
            else
            {
                return insight;
            }
        }
        else
        {
            if (key == 3)
            {
                return textsUntrans;
            }
            else
            {
                return textsTrans;
            }
        }

    }
}
