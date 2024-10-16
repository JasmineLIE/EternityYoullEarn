using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public SaveData saveData;
    public Artifact availArtData; //reference
    private void Awake()
    {
        //precurosry load
        LoadArtifacts();
    }

    private void LoadArtifacts()
    {
        if (saveData.GetDiscoveredCount() > 0)
        {
            availArtData.info = saveData.GetDiscoveredArtifacts();
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
}
