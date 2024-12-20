using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class RevelationsContainer : MonoBehaviour
{
    public GameObject[] rows;
    public int[] rowsCount;
    GameObject player;
    public GameObject revelationPrefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnRevelations();
    }

    public void SpawnRevelations()
    {
        if (player.GetComponent<Player>().saveData.ActivatedCount > 0)
        {
            List<ArtifactInfo> temp = player.GetComponent<Player>().saveData.GetActivatedArtifacts();

        
            foreach(ArtifactInfo info in temp)
            {

                AddArtifact(info);
               
            }

        } else
        {
            print("we have no revelations!");
        }
     

      
    }

    public void AddArtifact(ArtifactInfo info)
    {
        string shorthand = info.shorthand; //shorthand version for activated cards
        string name = info.name;
        float time = info.timeEffect;
        int[] eKeys = info.effectKey;
        int[] eVals = info.effect;
        int ID = info.spriteID;
        string textFile = info.desc;

        GameObject card = Instantiate(revelationPrefab);
        card.GetComponent<ActivatedArtifact>().SetUp(shorthand, name, time, eKeys, eVals, ID, textFile);


        if (rowsCount[0] < 4)
        {
            card.transform.SetParent(rows[0].transform); rowsCount[0]++;
        }
        else
        {
            card.transform.SetParent(rows[1].transform); rowsCount[1]++;
        }
    }
}
