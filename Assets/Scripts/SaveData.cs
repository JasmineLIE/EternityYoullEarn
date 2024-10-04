using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SaveData : MonoBehaviour
{
    //New game

    [SerializeField] private CompanionData _CompanionData = new CompanionData();
    [SerializeField] private PlayerData _PlayerData = new PlayerData();

    
    public void SaveIntoJson()
    {

        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/Playerdata.json";

        string companion = JsonUtility.ToJson(_CompanionData);
        string player = JsonUtility.ToJson(_PlayerData);
       

        if (!File.Exists(companionDataPath)) {
            GameStartValues();
        }

     
        System.IO.File.WriteAllText(companionDataPath, companion);
        System.IO.File.WriteAllText(playerDataPath, player);

        
    }

    private void GameStartValues()
    {

        //set everything to 0, like fresh game

        _CompanionData.Gwynhark_psycheLevel = 0;
        _CompanionData.Gwynhark_motivationLevel = 0;

        _CompanionData.Erem_psycheLevel = 0;
        _CompanionData.Erem_motivationLevel = 0;

        _CompanionData.Quan_psycheLevel = 0;
        _CompanionData.Quan_motivationLevel = 0;

        _PlayerData.insightVal = 0;
        _PlayerData.crystalEbonyVal = 0;
        _PlayerData.texts_untransVal = 0;
        _PlayerData.texts_transVal = 0;
        _PlayerData.MOHVal = 0;

    }

   
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
    public int crystalEbonyVal;
    public int texts_untransVal;
    public int texts_transVal;
    public int MOHVal;
}

