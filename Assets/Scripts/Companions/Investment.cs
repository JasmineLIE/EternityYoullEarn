using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investment : MonoBehaviour
{

    public int[] effects = new int[3];
   
    public int index;
    public int cost;


    public int[] values_r;
    public int values_t;

    public int[,] effect;

   
    public void SetEffect(int key, int val)
    {
        effects[key] = val;
    }

    public int GetEffect(int key)
    {
        return effects[key];
    }

    public void SetIndex(int val) { index = val; }

    public int GetIndex() { return index; }

    public void SetCost(int val) { cost = val; }

    public int GetCost() { return cost; }

    public void SetValues_r(int[] values) { values_r = values; }
    public int GetValues_r(int index) { return values_r[index]; }

    public void SetValues_t(int values) { values_t = values; }
    public int GetValues_t() { return values_t; }

    public void SetEffectArray(int[,] copy)
    {
        effect = copy;
    }

    public int GetEffectArray(int row, int col)
    {
        int val;

        val = effect[row, col];

        return val;
    }  
    
}
