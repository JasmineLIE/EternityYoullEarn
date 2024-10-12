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
                            { 20, 30, 50, 80 }, 
                            { 0, 0, 0, 0 }  };

  

    // Start is called before the first frame update
    void Start()
    {

        psyche.SetValues_r(p_r);
        motivation.SetValues_r(m_r);

        psyche.SetEffectArray(p_e);
        motivation.SetEffectArray(m_e);

        psyche.SetValues_t(5);
        motivation.SetValues_t(3);

        timeToCompleteTask = 30f;


        CharacterSetUp("Gwynhark");

    }


    public override string GetPsycheEffectDesc()
    {
        string effectText = "";
        switch (psyche.GetIndex())
        {
            case 0:
                effectText = "<b>Rewards:</b> " + ((psyche.GetEffect(1))-1) + " - " + ((psyche.GetEffect(2))-2) + " → " + psyche.GetEffect(1) + " - " + psyche.GetEffect(2);
                break;
            case 1:
                effectText = "<b>Rewards:</b> " + ((psyche.GetEffect(1)) - 3) + " - " + ((psyche.GetEffect(2)) - 3) + " → " + psyche.GetEffect(1) + " - " + psyche.GetEffect(2);
                break;
            case 2:
                effectText = "<b>Rewards:</b> " + ((psyche.GetEffect(1)) - 3) + " - " + ((psyche.GetEffect(2)) - 6) + " → " + psyche.GetEffect(1) + " - " + psyche.GetEffect(2);
                break;
            case 3:
                effectText = "<b>Rewards:</b> " + ((psyche.GetEffect(1)) - 7) + " - " + ((psyche.GetEffect(2)) - 13) + " → " + psyche.GetEffect(1) + " - " + psyche.GetEffect(2);
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
                effectText = "<b>Efficiency:</b> " + motivation.GetEffect(1) + "%"; 
                break;

            case 1:
           
       
            case 2:
              
            case 3:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffect(1) + "%" + "\n" + "<b>Mark of Humanity Rate:</b> " + motivation.GetEffect(2) + "%";
                break;
        }
        return effectText;
    }

    
}
