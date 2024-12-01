using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class SaveData : MonoBehaviour
{
    //New game

    [SerializeField] private CompanionData _CompanionData = new CompanionData();
    [SerializeField] private PlayerData _PlayerData = new PlayerData();

    //Artifacts


    [SerializeField] private Artifact _ArtifactData = new Artifact();

    
    public void SaveIntoJson()
    {
        //Create strings for path direction and file name
        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/PlayerData.json";
        string artifactDataPath = Application.persistentDataPath + "/ArtifactData.json";

        //serialize into JSon data
        string companion = JsonUtility.ToJson(_CompanionData);
        string player = JsonUtility.ToJson(_PlayerData);
        string artifact = JsonUtility.ToJson(_ArtifactData);


        //Default data set is adjusted in Inspector


        //In the chosen directory, create and save a file
        System.IO.File.WriteAllText(companionDataPath, companion);
        System.IO.File.WriteAllText(playerDataPath, player);
        System.IO.File.WriteAllText(artifactDataPath, artifact);


    }

    
    public void LoadJson()
    {
        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/PlayerData.json";
        string artifactDataPath = Application.persistentDataPath + "/ArtifactData.json";


        if (!DoesSaveExist())
        {
            SaveIntoJson();
        }
        else
        {
            //read entire file(s) and save its content(s)
            string companionDataContents = File.ReadAllText(companionDataPath);
            string playerDataContents = File.ReadAllText(playerDataPath);
            string artifactDataContents = File.ReadAllText(artifactDataPath);

            //Deserialize the JSON data
            _CompanionData = JsonUtility.FromJson<CompanionData>(companionDataContents);
            _PlayerData = JsonUtility.FromJson<PlayerData>(playerDataContents);
            _ArtifactData = JsonUtility.FromJson<Artifact>(artifactDataContents);
        }


     

        
    }

    /*
     * This function returns true or false, depending if there exists save files.
     * False if there is no save file detected in the local directory, true if otherwise.
     */
    public static bool DoesSaveExist()
    {
        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/PlayerData.json";
        string artifactDataPath = Application.persistentDataPath + "/ArtifactData.json";

        if (!File.Exists(playerDataPath) || !File.Exists(companionDataPath) || !File.Exists(artifactDataPath))
        {
            
            return false;
        }
      
        return true;
    }

    public void LoadGameStart()
    {
      

        BackgroundTasks.EremHasTask = false;
        BackgroundTasks.QuanHasTask = false;
        BackgroundTasks.QuanHasTask = false;
        BackgroundTasks.CanCollect = false;
     

        SceneManager.LoadScene("PersistentGame");
        CustomSceneManager.ChangeScene(1);


    }

    public static void DeleteSave()
    {
        string companionDataPath = Application.persistentDataPath + "/CompanionData.json";
        string playerDataPath = Application.persistentDataPath + "/PlayerData.json";
        string artifactDataPath = Application.persistentDataPath + "/ArtifactData.json";


        System.IO.File.Delete(playerDataPath);
        System.IO.File.Delete(companionDataPath);
        System.IO.File.Delete(artifactDataPath);


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

    public int GetInsight()
    {
        return _PlayerData.insightVal;
    }

    public int GetMarksOfHumanity()
    {
        return _PlayerData.MOHVal;
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

    public void IncrementTotalInvestments()
    {
        _PlayerData.totalInvestments++;
        SaveIntoJson();
    }

    public int GetIncremenetTotal()
    {
        return _PlayerData.totalInvestments;
    }

    public void SetMOHIncrement(int val)
    {
        _PlayerData.MOHIncrementVal += val;
        SaveIntoJson();
    }

    public int GetMOHIncrement()
    {
        return _PlayerData.MOHIncrementVal;
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
                companionData[0] = _CompanionData.Gwynhark_psycheLevel;
                companionData[1] = _CompanionData.Gwynhark_motivationLevel;
                break;


            case "Erem":
                companionData[0] = _CompanionData.Erem_psycheLevel;
                companionData[1] = _CompanionData.Erem_motivationLevel;
                break;

            case "Quan":
                companionData[0] = _CompanionData.Quan_psycheLevel;
                companionData[1] = _CompanionData.Quan_motivationLevel;
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

    public int GetExtraMarksGenerated()
    {
        return _CompanionData.extraMarksGenerated;
    }


    public void SetExtraMarksGenerated(int val)
    {
        _CompanionData.extraMarksGenerated += val;
        SaveIntoJson();
    }

    public int GetStudiedArtifactsVal()
    {
        return _CompanionData.Erem_studiedArtifactsVal;
    }

    public void SetStudiedArtifactsVal(int val)
    {
        _CompanionData.Erem_studiedArtifactsVal += val;
        SaveIntoJson();
    }

    public void ResetStudiedArtifactVal()
    {
        _CompanionData.Erem_studiedArtifactsVal = 0;
        SaveIntoJson();
    }
    //-----

    //----- Artifact Handler -----

    /*
     * This function will randomize artifacts discovered, placing them at the end of the list, so that all elements at the front are undiscovered, eventually working within the list to sort all
     * There should be an edge case preceding this to ensure we do not go out of array index
     * Working with index is tricky when having a counter that counts normally.  Some minor spahgetti
     */
    public ArtifactInfo DiscoverArtifact()
    {

        if (_ArtifactData.pointer >= 1)
        {
            //Randomly select an undiscovered artifact
            int random = Random.Range(0, _ArtifactData.pointer);

            //We will set the select undiscovered artifact to discover, and move it to the end of the "discovered" portion of the list, swapping places with what element was at the end


            ArtifactInfo discoveredTemp = _ArtifactData.info[random];
            ArtifactInfo undiscoveredTemp = _ArtifactData.info[_ArtifactData.pointer];

            //swap
            _ArtifactData.info[random] = undiscoveredTemp;
            _ArtifactData.info[_ArtifactData.pointer] = discoveredTemp;

            _ArtifactData.discovered++;
            _ArtifactData.pointer--;
            SaveIntoJson();
            return discoveredTemp;

        } else if (_ArtifactData.pointer == 0)
        {
            _ArtifactData.pointer--;
            _ArtifactData.discovered++;
            SaveIntoJson();
            return _ArtifactData.info[0];
        }

        return null; //An error somehow occured

    }

    public List<ArtifactInfo> GetDiscoveredArtifacts()
    {
        List<ArtifactInfo> temp = new List<ArtifactInfo>();

        //we +1 because pointer is -1
        int difference = (_ArtifactData.info.Count - (_ArtifactData.pointer + 1));

        for (int i = 0; i < difference; i++)
        {
            if (!_ArtifactData.info[i].activated)
            {
                temp.Add(_ArtifactData.info[i]);
            }
        }


        return temp;
    }

   
    public ArtifactInfo ActivateArtifact(string name)
    {
        //return artifact based on name

        foreach(ArtifactInfo artifact in _ArtifactData.info)
        {
            if (artifact.name ==  name)
            {
                artifact.activated = true;
                _ArtifactData.activatedArtifacts.Add(artifact);
                SaveIntoJson();

                return artifact;
            }
        }

        return null; // we don't have it
       
    }

    public List<ArtifactInfo> GetActivatedArtifacts()
    {
        return _ArtifactData.activatedArtifacts;
    }

    public int GetDiscoveredCount()
    {
        return _ArtifactData.discovered;
    }

    public int GetArtifactListSize()
    {
        return _ArtifactData.info.Count;
    }

    public int GetArtifactPointer()
    {
        return _ArtifactData.pointer;
    }

  

    public int ActivatedCount
    {
        get
        {
            return _ArtifactData.activated;
        }

        set
        {
            //increment by calling get and incrementing it, then applying to set
            _ArtifactData.activated = value;
            SaveIntoJson();
        }
    }
}

[System.Serializable]
public class CompanionData
{
    public int Gwynhark_psycheLevel;
    public int Gwynhark_motivationLevel;

    public int Erem_psycheLevel;
    public int Erem_motivationLevel;
    public int Erem_studiedArtifactsVal;

    public int Quan_psycheLevel;
    public int Quan_motivationLevel;

    public int extraMarksGenerated;

   
 
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
    public int MOHIncrementVal;
    public int totalInvestments;
 
   
}

[System.Serializable]
public class Artifact
{
   
    public int pointer;
    public int discovered;

    //we mostly need this for the tt on The Gate -- also good to try {get; set;}
    public int activated;
    

    //Holds all Artifacts thus far
   public List<ArtifactInfo> info = new List<ArtifactInfo>();
    public List<ArtifactInfo> activatedArtifacts = new List<ArtifactInfo>();    

 
}

[System.Serializable] 
public class ArtifactInfo
{
    public int spriteID;
    public bool activated;
    public string shorthand;
    public string name;
    public string desc;
    public string lore;

    public int[] cost;
    public int[] costKey;

    public int[] effect;
    public int[] effectKey;

    public float timeEffect;
}

