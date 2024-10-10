using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quan : Companion
{
    private int[] psyche_r = { 1, 2, 3, 8 };
    private int[] motivation_r = { 0, 1, 3, 5 };
    private int psyche_t = 5;
    private int motivation_t = 3;

    // Start is called before the first frame update
    void Start()
    {
        CharacterSetUp("Quan", psyche_r, motivation_r, psyche_t, motivation_t);
    }

   
}
