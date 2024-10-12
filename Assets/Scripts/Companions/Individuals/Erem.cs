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
    private int[,] p_e = {  { 20, 40, 70, 100 }, 
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
        psyche.SetValues_r(p_r);
        motivation.SetValues_r(m_r);

        psyche.SetEffectArray(p_e);
        motivation.SetEffectArray(m_e);

        psyche.SetValues_t(5);
        motivation.SetValues_t(3);

        timeToCompleteTask = 45f;

        CharacterSetUp("Erem");


       
    }

    

    public override string GetPsycheEffectDesc()
    {
        string effectText ="";
        switch (psyche.GetIndex())
        {
            case 0:
                effectText = "<b>Marks of Humanity Rate:</b> " + psyche.GetEffect(0) + "%" + " → " + psyche.GetEffectArray(0, 0) + "%";
                break;
            case 1:
                effectText = "<b>Marks of Humanity Rate:</b> " + psyche.GetEffect(0) + "%" + " → " + psyche.GetEffectArray(0,1) + "%" + "\n" + "<b>Marks Earned:</b> +" + psyche.GetEffectArray(1,1) + " Marks for ALL companions";
                break;
            case 2:
                effectText = "<b>Marks of Humanity Rate:</b> " + psyche.GetEffect(0) + "%" + " → " + psyche.GetEffectArray(0, 2) + "%";
                break;
             case 3:
                effectText = "<b>Marks of Humanity Rate: Gauranteed</b>" + "\n" + "<b>Marks Earned:</b> +" + psyche.GetEffectArray(1,3) + " Marks for ALL companions";
                break;
        }

        return effectText;
    }

    public override string GetMotivationEffectDesc()
    {
        string effectText = "";

        switch (motivation.GetIndex())
        {
            case 0:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffect(0) + "%" + " → " + motivation.GetEffectArray(0, 0) + "%";
                break;
            case 1:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffect(0) + "%" + " → " + motivation.GetEffectArray(0, 1) + "%" + "\n" + "<b>Study Translated Texts:</b> " + (motivation.GetEffect(1) + " → " + motivation.GetEffectArray(1, 1));
                break;

            case 2:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffect(0) + "%" + " → " + motivation.GetEffectArray(0,2)+ "%";
                break;

            case 3:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffect(0) + "%" + " → " + motivation.GetEffectArray(0,3) + "%" + "\n" + "<b>Study Translated Texts:</b> " + (motivation.GetEffect(1) + " → " + motivation.GetEffectArray(1,3));
                break;
        }
        return effectText;
    }
}
