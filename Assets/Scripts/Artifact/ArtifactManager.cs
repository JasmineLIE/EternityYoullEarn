using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public SaveData saveData;
    public Artifact availArtData; //reference
    public GameObject UnactivatedPrefab;
    public GameObject frame;


    private void Start()
    {
     
    }
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
           
        }
     
    }

    public ArtifactInfo DiscoverArtifact()
    {
        if (saveData.GetArtifactPointer() >= 0)
        {
            ArtifactInfo temp = saveData.DiscoverArtifact();
        
            return temp;
        } else
        {
          
            return null;
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
        float timeEffect = availArtData.info[cardIndex].timeEffect;
       
       
        GameObject card = Instantiate(UnactivatedPrefab);
        card.transform.SetParent(frame.transform);
        card.GetComponent<UnactivatedArtifacts>().SetUp(name, desc, costKeys, costs, effectKeys, effects, timeEffect);
    }
}
