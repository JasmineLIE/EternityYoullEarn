using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Gwynhark : Companion
{
    private int[] p_r = { 0, 1, 2, 4 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- MIN for resources collected
    //2nd array -- MAX for resources collected
    //3rd array -- N/A
    private int[,] p_e = {  { 2, 5, 8, 15 }, 
                            { 5, 8, 12, 25 }, 
                            { 0, 0, 0, 0 }  };

    //1st array -- efficiency
    //2nd array -- MOH Rate
    //3rd array -- N/A
    private int[,] m_e = { { 10, 15, 25, 35 }, 
                            { 0, 10, 25, 40 }, 
                            { 0, 0, 0, 0 }  };


    // Start is called before the first frame update
    void Start()
    {

        psyche_r = p_r;
        motivation_r = m_r;

        psycheEffect = p_e;
        motivationEffect = m_e;

        psyche_t = 5;
        motivation_t = 3;
        CharacterSetUp("Gwynhark");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
