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
                                { 0, 3, 0, 10 }, 
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

        timeToCompleteTask = 45f;

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
                effectText = "<b>Marks of Humanity Rate:</b> " + effect_p_1 + "%";
                break;
            case 1:
                effectText = "<b>Marks of Humanity Rate:</b> " + effect_p_1 + "%" + "\n" + "<b>Marks Earned:</b> +" + effect_p_2 + " Marks for ALL companions";
                break;
            case 2:
                effectText = "<b>Marks of Humanity Rate:</b> " + effect_p_1 + "%";
                break;
             case 3:
                effectText = "<b>Marks of Humanity Rate: Gauranteed</b>" + "\n" + "<b>Marks Earned:</b> +" + effect_p_2 + " Marks for ALL companions";
                break;
        }

        return effectText;
    }

    public override string GetMotivationEffectDesc()
    {
        string effectText = "";

        switch (motivationIndex)
        {
            case 0:
                 

            case 1:
                effectText = "<b>Efficiency:</b> " + effect_m_1 + "%" + "\n" + "<b>Study Translated Texts:</b> " + (effect_m_2 - 1) + " → " + effect_m_2;
                break;

            case 2:
                effectText = "<b>Efficiency:</b> " + effect_m_1+ "%";
                break;

            case 3:
                effectText = "<b>Efficiency:</b> " + effect_m_1 + "%" + "\n" + "<b>Study Translated Texts:</b> " + (effect_m_2 - 1) + " → " + effect_m_2;
                break;
        }
        return effectText;
    }
}
