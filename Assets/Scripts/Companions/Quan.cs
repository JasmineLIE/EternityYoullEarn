using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quan : Companion
{

    private int untranslatedTextsThresh;

    private int[] p_r = { 1, 2, 3, 8 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- rate to earn Marks
    //2nd array -- How many untranslated texts can be translated at a time
    //3rd array -- extra Marks earned for ALL companions
    private int[,] p_e = { { 20, 40, 60, 100 }, 
                                { 2, 4, 4, 4 }, 
                                { 0, 0, 0, 5 } };

    //1st array -- efficiency
    //2nd array -- Extra translated texts earned rate
    //3rd array -- N/A
    private int[,] m_e = { { 10, 30, 30, 50 }, 
                                { 50, 50, 100, 100 }, 
                                { 0, 0, 0, 0 } };


    // Start is called before the first frame update
    void Start()
    {
        psyche_r = p_r;
        motivation_r = m_r;

        psycheEffect = p_e;
        motivationEffect = m_e;

        psyche_t = 5;
        motivation_t = 3;

        timeToCompleteTask = 25f;

       

        CharacterSetUp("Quan");

    }

    public override string GetPsycheEffectDesc()
    {
        string effectText = "";
        switch (psycheIndex)
        {
            case 0:
                effectText = "<b>Marks of Humanity Rate:</b> " + effect_p_1 + "%";
                break;
            case 1:
                effectText = "<b>Marks of Humanity Rate:</b> " + effect_p_1 + "%" + "\n" + "<b>Translation Texts Limit:</b> +" + (effect_p_2-2) + " → " + effect_p_2;
                break;
            case 2:
                effectText = "<b>Marks of Humanity Rate:</b> " + effect_p_1 + "%";
                break;
            case 3:
                effectText = "<b>Marks of Humanity Rate: Gauranteed</b>" + "\n" + "<b>Marks Earned:</b> +" + effect_p_3 + " addtional Marks for ALL companions";
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
                effectText = "<b>Efficiency:</b> " + effect_m_1 + "%" + "\n" + "<b>Translated Texts Earned:</b> " + effect_m_2 + "% chance for +1 extra";
                break;

            case 1:
                effectText = "<b>Efficiency:</b> " + effect_m_1+"%";
                break;

            case 2:
                effectText = "<b>Translated Texts Earned: Gauranteed +1 Extra"; 
                break;

            case 3:
                effectText = "<b>Efficiency:</b> " + effect_m_1+"%";
                break;
        }
        return effectText;
    }

    public override void CompleteTask()
    {

        base.CompleteTask();
    }

    protected override void UpdatePsycheEffect()
    {

        untranslatedTextsThresh = psycheEffect[1, psycheIndex];
        //Set MoH Rate
        if (psycheIndex == 0)
        {
            mohRate = 10;
        }
        else
        {
            mohRate = psycheEffect[0, psycheIndex - 1];
        }
    

        base.UpdatePsycheEffect();
    }
    protected override void UpdateMotivationEffect()
    {
        base.UpdateMotivationEffect();
    }
}
