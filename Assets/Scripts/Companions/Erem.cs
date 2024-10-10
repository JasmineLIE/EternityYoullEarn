using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erem : Companion
{
    
    private int[] psyche_r = { 2, 3, 4, 5 };
    private int[] motivation_r = { 0, 1, 3, 5 };
    private int psyche_t = 5;
    private int motivation_t = 3;
    void Start()
    {
        CharacterSetUp("Erem", psyche_r, motivation_r, psyche_t, motivation_t);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
