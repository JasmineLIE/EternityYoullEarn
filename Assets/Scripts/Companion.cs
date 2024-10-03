using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Companion : MonoBehaviour
{
    //Data Variables

    private string comName;
    private List<string> barks = new List<string>();
    private int psycheLevel, motivationLevel;

   
    public void CharacterSetUp(string charName, string[] barks)
    {
        //TODO: Bio
        //not really concerned about saved data for now

        comName = charName;

        setBarks(barks); 

        //Starting investment level
        psycheLevel = 0;
        motivationLevel = 0;

    }

    public void setBarks(string[] newBarks)
    {
        //If we have time to replace barks as Companion gains investments to reflect state
        barks.Clear();

        //Add starting barks to the character's bark pool
        for (int i = 0; i < newBarks.Length; i++)
        {
            barks.AddRange(newBarks[i]);
        }

    }
}
