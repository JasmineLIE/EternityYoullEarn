using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Erem : Companion
{
    
  
    private int[] p_r= { 2, 3, 4, 5 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- MOH earn rate
    //2nd array -- Additional marks earned by companions
    //3rd array -- N/A
    private int[,] p_e = {  { 20, 40, 70, 199 }, 
                                { 0, 3, 3, 10 }, 
                                { 0, 0, 0, 0 }  };

    //1st array -- efficiency
    //2nd array -- Untranslated texts they can study at a time
    //3rd array -- N/A
    private int[,] m_e = {  { 10, 15, 30, 50 }, 
                                { 4, 5, 5, 6 }, 
                                { 0, 0, 0, 0 }  };

    private string[] p_e_d = new string[4];
    private string[] m_e_d = new string[4];
    void Start()
    {
        psyche_r = p_r;
        motivation_r = m_r;

        psycheEffect = p_e;
        motivationEffect = m_e;

        psyche_t = 5;
        motivation_t = 3;
        CharacterSetUp("Erem");


       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string GetPsycheEffectDesc()
    {
        string effectText ="";
        switch (psycheIndex)
        {
            case 0:
                effectText = "Marks of Humanity Rate: " + effect_p_1 + "%";
                break;
            case 1:
                break;
            case 2:
                break;
             case 3:
                break;
        }

        return effectText;
    }

}
