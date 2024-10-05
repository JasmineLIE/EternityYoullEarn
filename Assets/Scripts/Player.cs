using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {

        //Game start, load player data from local directory
       saveData.LoadJson();
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
            saveData.SaveCrystalEbonies(val);
        } 
        else if (key < 2)
        {
            if (key == 1)
            {
                marksOfHumanity += val;
                saveData.SaveMOH(val);
            } 
            else
            {
                insight += val;
                saveData.SaveInsight(val);
            }
        } 
        else
        {
            if (key == 3)
            {
                textsUntrans += val;
                saveData.SaveUntransTexts(val);
            } 
            else
            {
                textsTrans += val;
                saveData.SaveTransTexts(val);
            }
        }
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
