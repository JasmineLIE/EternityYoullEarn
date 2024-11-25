using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gwynhark : Companion
{

    
    private int[] p_r = { 0, 1, 2, 4 };
    private int[] m_r = { 1, 3, 6, 9 };

  
    public int MIN_resources;
    public int MAX_resources;
    //1st array -- MIN for resources collected
    //2nd array -- MAX for resources collected
    //3rd array -- N/A
    private int[,] p_e = {  { 2, 5, 8, 15 }, 
                            { 5, 8, 12, 25 }, 
                            { 0, 0, 0, 0 }  };

    //1st array -- efficiency
    //2nd array -- MOH Rate
    //3rd array -- N/A
    private int[,] m_e = { { 30, 40, 50, 60 }, 
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
        insightCost = 100;

        CharacterSetUp("Gwynhark");

        //once after set up
        specialVal1 = MIN_resources;
        specialVal2 = MAX_resources;

    }


    public override string GetPsycheEffectDesc()
    {
        string effectText = "<b>Rewards:</b> " + MIN_resources + " - " + MAX_resources + " → " + psyche.GetEffectArray(0, psyche.GetIndex()+1) + " - " + psyche.GetEffectArray(1, psyche.GetIndex()+1);
        

        return effectText;
    }

    public override string GetMotivationEffectDesc()
    {
        string effectText = "";

        switch (motivation.GetIndex())
        {
            case 0:
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0, 0); 
                break;

            case 1:
           
       
            case 2:
              
            case 3:
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0, motivation.GetIndex()+1) + "%" + "\n" + "<b>Mark of Humanity Rate:</b> " + mohRate + "%" + " → " + motivation.GetEffectArray(1, motivation.GetIndex()+1) + "&";
                break;
        }
        return effectText;
    }

    protected override void SetDefaultValues()
    {
        base.SetDefaultValues();
     
        //set min and max values for scavanging
        psyche.SetEffect(0, psyche.GetEffectArray(0,0));
        psyche.SetEffect(1, psyche.GetEffectArray(1, 0));
        MIN_resources = psyche.GetEffect(0);
        MAX_resources = psyche.GetEffect(1);

      
    }

    protected override void UpdatePsycheEffect()
    {
        base.UpdatePsycheEffect();

        MIN_resources = psyche.GetEffect(0);
        MAX_resources = psyche.GetEffect(1);

        //each time after upgrade
        specialVal1 = MIN_resources;
        specialVal2 = MAX_resources;
    }

    protected override void UpdateMotivationEffect()
    {
        base.UpdateMotivationEffect();

        efficiency = motivation.GetEffect(0);
        mohRate = motivation.GetEffect(1);
    }

    public int[] GenerateYield(int crystalEbos, int untransTexts)
    {
        int ceYield = 0;
        int utYield = 0;


        for (int i = 0; i < crystalEbos; i++)
        {

            ceYield += Random.Range(MIN_resources, MAX_resources);

        }

        for (int i = 0; i < untransTexts; i++)
        {

            utYield += Random.Range(MIN_resources, MAX_resources);

        }

        int[] yields = {ceYield, utYield };
        return yields;
    }
   public void CompleteTask(int ceYield, int utYield)
    {
      
        print("The crystal ebony yield is: " + ceYield);
        print("The untranslated texts yield is: " + utYield);
       

        player.GetComponent<Player>().SetResource(2, ceYield);
        player.GetComponent<Player>().SetResource(3, utYield);
        CompleteTask();

    }


   

}
