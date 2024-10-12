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

        timeToCompleteTask = 30f;


        CharacterSetUp("Gwynhark");

        //Set up MoH Rate
        if (motivationIndex == 0)
        {
            mohRate = 10;
        } else
        {
            mohRate = motivationEffect[1, motivationIndex - 1];
        }
    }


    public override string GetPsycheEffectDesc()
    {
        string effectText = "";
        switch (psycheIndex)
        {
            case 0:
                effectText = "<b>Rewards:</b> " + ((effect_p_1)-1) + " - " + ((effect_p_2)-2) + " → " + effect_p_1 + " - " + effect_p_2;
                break;
            case 1:
                effectText = "<b>Rewards:</b> " + ((effect_p_1) - 3) + " - " + ((effect_p_2) - 3) + " → " + effect_p_1 + " - " + effect_p_2;
                break;
            case 2:
                effectText = "<b>Rewards:</b> " + ((effect_p_1) - 3) + " - " + ((effect_p_2) - 6) + " → " + effect_p_1 + " - " + effect_p_2;
                break;
            case 3:
                effectText = "<b>Rewards:</b> " + ((effect_p_1) - 7) + " - " + ((effect_p_2) - 13) + " → " + effect_p_1 + " - " + effect_p_2;
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
