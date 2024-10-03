using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Companion : Clickable
{
    //Data Variables

    private string comName;
    private List<string> barks = new List<string>();

    //These hold the 'r' value from the spreadsheet, incrementing each level
    private int[] psycheFactors = new int[4];
    private int[] motivationFactors = new int[4];

    //Represents what investment level the player is currently on
    private int psycheIndex;
    private int motivationIndex; 

    //These values represent the current cost of the invesment
    private int psycheCost;
    private int motivationCost;

    //This value represents 't' from the Spreadsheet
    private int growthFactor;

    private void Awake()
    {
        growthFactor = 5;

        //Start at 0 because we are accessing an array of values
        psycheIndex = 0;
        motivationIndex = 0;
    }

    public void CharacterSetUp(string charName, string[] barks, int[] psyche, int[] motivation)
    {
        //TODO: Bio
        //not really concerned about saved data for now

        comName = charName;

        setBarks(barks);

        //Set up investment growth increments
        for (int i = 0; i < psycheFactors.Length; i++)
        {
            psycheFactors[i] = psyche[i];
            motivationFactors[i] = motivation[i];
        }
    

    }

    public override void Clicked()
    {
        //Shoud open a UI when clicked
        throw new System.NotImplementedException();
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

    public int PsycheGrowthModel(int r, int t)
    {
        return ((1 + (r * 2))*t); 
    }

    public int MotivationGrowthModel(int r, int t)
    {
        return (r * t) * t;
    }
 }
