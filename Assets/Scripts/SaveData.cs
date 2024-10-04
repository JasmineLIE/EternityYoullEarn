using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    //New game

    [SerializeField] private CompanionData _CompanionData = new CompanionData();
    [SerializeField] private PlayerData _PlayerData = new PlayerData();

    public void SaveIntoJson()
    {
        string companion = JsonUtility.ToJson(_CompanionData);
        string player = JsonUtility.ToJson(_PlayerData);

        //to check if the game has been started before.  if not, set data of our serialized sets to default game start
        string target = Application.persistentDataPath + "/CompanionData.json";

        if (!File.Exists(target)) {
            GameStartValues();
        } 
     System.IO.File.WriteAllText(Application.persistentDataPath + "/CompanionData.json", companion);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", player);
    }

    private void GameStartValues()
    {

        //set everything to 0, like fresh game

        _CompanionData.gwyn_motivationLevel = 0;
        _CompanionData.gwyn_motivationLevel = 0;

        _CompanionData.erem_motivationLevel = 0;
        _CompanionData.erem_motivationLevel = 0;

        _CompanionData.quan_motivationLevel = 0;
        _CompanionData.quan_motivationLevel = 0;

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
    public int gwyn_psycheLevel;
    public int gwyn_motivationLevel;

    public int erem_psycheLevel;
    public int erem_motivationLevel;

    public int quan_psycheLevel;
    public int quan_motivationLevel;
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