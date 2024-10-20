using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public SaveData saveData;
    public Artifact availArtData; //reference
    public GameObject UnactivatedPrefab;
    public GameObject frame;
  
    public void LoadArtifacts()
    {
     
        if (saveData.GetDiscoveredCount() > 0)
        {   
            //assigns a subsidized list containing all discovered artifacts (uses .GetRange())
            availArtData.info = saveData.GetDiscoveredArtifacts();

            for (int i = 0; i < availArtData.info.Count; i++)
            {
                
                    SpawnCard(i);
                
            }
        } else
        {
            print("We have no discovered artifacts!");
        }
     
    }

    public bool DiscoverArtifact()
    {
        if (saveData.GetArtifactPointer() >= 0)
        {
            saveData.DiscoverArtifact();
            LoadArtifacts();
            return true;
        } else
        {
            print("We have no more artifacts to discover");
            return false;
        }
    
    }

    private void SpawnCard(int cardIndex)
    {
        string name = availArtData.info[cardIndex].name;
        string desc = availArtData.info[cardIndex].desc;
        int[] costKeys = availArtData.info[cardIndex].costKey;
        int[] costs = availArtData.info[cardIndex].cost;
        int[] effects = availArtData.info[cardIndex].effect;
        int[] effectKeys = availArtData.info[cardIndex].effectKey;

        print("Spawning " + cardIndex);
        GameObject card = Instantiate(UnactivatedPrefab);
        card.transform.SetParent(frame.transform);
        card.GetComponent<UnactivatedArtifacts>().SetUp(name, desc, costKeys, costs, effectKeys, effects);
    }
}
