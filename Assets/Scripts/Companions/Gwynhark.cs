using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Gwynhark : Companion
{
    private int[] psyche_r = { 0, 1, 2, 4 };
    private int[] motivation_r = { 0, 1, 3, 5 };
    private int psyche_t = 5;
    private int motivation_t = 3;
    // Start is called before the first frame update
    void Start()
    {
        CharacterSetUp("Gwynhark", psyche_r, motivation_r, psyche_t, motivation_t);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
