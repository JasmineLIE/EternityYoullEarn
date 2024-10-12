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

    public override string GetPsycheEffectDesc()
    {
        string effectText = "";
        switch (psycheIndex)
        {
            case 0:
                effectText = ((effect_p_1)-1) + " (MIN) - " + ((effect_p_2)-2) + " (MAX) > " + effect_p_1 + " (MIN) - " + effect_p_2 + " (MAX)";
                break;
            case 1:
                effectText = ((effect_p_1) - 3) + " (MIN) - " + ((effect_p_2) - 3) + " (MAX) > " + effect_p_1 + " (MIN) - " + effect_p_2 + " (MAX)";
                break;
            case 2:
                effectText = ((effect_p_1) - 3) + " (MIN) - " + ((effect_p_2) - 6) + " (MAX) > " + effect_p_1 + " (MIN) - " + effect_p_2 + " (MAX)";
                break;
            case 3:
                effectText = ((effect_p_1) - 7) + " (MIN) - " + ((effect_p_2) - 13) + " (MAX) > " + effect_p_1 + " (MIN) - " + effect_p_2 + " (MAX)";
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
                effectText = "<b>Efficiency:</b> " + effect_m_1 + "%"; 
                break;

            case 1:
           
       
            case 2:
              
            case 3:
                effectText = "<b>Efficiency:</b> " + effect_m_1 + "%" + "\n" + "<b>Mark of Humanity Rate:</b> " + effect_m_2 + "%";
                break;
        }
        return effectText;
    }
}
