using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class SaveData : MonoBehaviour
{
    //New game

    [SerializeField] private CompanionData _CompanionData = new CompanionData();
    [SerializeField] private PlayerData _PlayerData = new PlayerData();

   
    public void SaveIntoJson()
    {
        //Create strings for path direction and file name
        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/PlayerData.json";

        //serialize into JSon data
        string companion = JsonUtility.ToJson(_CompanionData);
        string player = JsonUtility.ToJson(_PlayerData);
       
        //Default data set is adjusted in Inspector

        print("Writing save file...");
        //In the chosen directory, create and save a file
        System.IO.File.WriteAllText(companionDataPath, companion);
        System.IO.File.WriteAllText(playerDataPath, player);

        
    }

    public void LoadJson()
    {
        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/PlayerData.json";

        if (!File.Exists(playerDataPath) && !File.Exists(companionDataPath))
        {
           
            SaveIntoJson();
        } else
        {
            print("Game data found!  Loading in...");
            //read entire file(s) and save its content(s)
            string companionDataContents = File.ReadAllText(companionDataPath);
            string playerDataContents = File.ReadAllText(@playerDataPath);

            //Deserialize the JSON data
            _CompanionData = JsonUtility.FromJson<CompanionData>(companionDataContents);
            _PlayerData = JsonUtility.FromJson<PlayerData>(playerDataContents);

        }
    }

    public void LoadGameStart()
    {
       
        LoadJson();
        SceneManager.LoadScene("TheGate");
    }

  
    //-----Player Data Functions-----
   public int[] LoadPlayerData()
    {
        //Ensure data is up to date bfore loading
        LoadJson();

        int[] playerData = new int[5];

        /**
       * (Referenced like array)
       * Insight = 0
       * Marks of Humanity = 1
       * Crystal Ebonies = 2
       * Untranslated Texts = 3
       * Translated Texts = 4
       */

        playerData[0] = _PlayerData.insightVal;
        playerData[1] = _PlayerData.MOHVal;
        playerData[2] = _PlayerData.crystalEbonyVal;
        playerData[3] = _PlayerData.texts_untransVal;
        playerData[4] = _PlayerData.texts_transVal;
        return playerData;
    }

    public void SaveInsight(int val)
    {
        _PlayerData.insightVal = val;
        SaveIntoJson();
    }

    public void SaveMOH(int val)
    {
        _PlayerData.MOHVal = val;
        SaveIntoJson();
    }

    public void SaveCrystalEbonies(int val)
    {
        _PlayerData.crystalEbonyVal = val;
        SaveIntoJson();
    }

    public void SaveUntransTexts(int val)
    {
        _PlayerData.texts_untransVal = val;
        SaveIntoJson();
    }
    public void SaveTransTexts(int val) { 
        _PlayerData.texts_transVal = val;
        SaveIntoJson();
    }

    public void SaveIncrementVal(int val)
    {
        _PlayerData.incrementVal = val;
        SaveIntoJson();
    }
    public int GetInsightIncrementVal()
    {
        return _PlayerData.incrementVal;
    }
   //-----

    //----- Companion Data Functions -----

    public int[] LoadCompanionData(string key)
    {
        //Ensure data is up to date before loading
        LoadJson();

        int[] companionData = new int[2];

        switch (key)
        {
            /**
             * 0 - Gwynhark
             * 1 - Erem
             * 2 - Quan
             */
            case "Gwynhark":
                companionData[1] = _CompanionData.Gwynhark_psycheLevel;
                companionData[0] = _CompanionData.Gwynhark_motivationLevel;
                break;
               
                
            case "Erem":
                companionData[1] = _CompanionData.Erem_psycheLevel;
                companionData[0] = _CompanionData.Erem_motivationLevel;
                break;
                
            case "Quan":
                companionData[1] = _CompanionData.Quan_psycheLevel;
                companionData[0] = _CompanionData.Quan_motivationLevel;
                break;
        }
        return companionData;
    }

    public void SaveCompanionPsyche(string key)
    {
        switch (key)
        {
            
            case "Gwynhark":
                _CompanionData.Gwynhark_psycheLevel++;
               
                break;


            case "Erem":
                _CompanionData.Erem_psycheLevel++;

                break;

            case "Quan":
                _CompanionData.Quan_psycheLevel++;
                break;
        }
        SaveIntoJson();
    }

   
    public void SaveCompanionMotivation(string key)
    {
        switch (key)
        {
            
            case "Gwynhark":
                _CompanionData.Gwynhark_motivationLevel++;
                break;


            case "Erem":
                _CompanionData.Erem_motivationLevel++;
                break;

            case "Quan":
                _CompanionData.Quan_motivationLevel++;
                break;
        }

        SaveIntoJson();
    }
    //-----
}

[System.Serializable]
public class CompanionData
{
    public int Gwynhark_psycheLevel;
    public int Gwynhark_motivationLevel;

    public int Erem_psycheLevel;
    public int Erem_motivationLevel;

    public int Quan_psycheLevel;
    public int Quan_motivationLevel;

 
}

[System.Serializable]
public class PlayerData
{
    public int insightVal;
    public int MOHVal;
    public int crystalEbonyVal;
    public int texts_untransVal;
    public int texts_transVal;
    public int incrementVal;
   
}

