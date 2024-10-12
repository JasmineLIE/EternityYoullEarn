using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Quan : Companion
{

    public int MAX_translatedTexts;
    public int MIN_translatedTexts = 2;
    private int extraRewardsRate;

    private int[] p_r = { 1, 2, 3, 8 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- rate to earn Marks
    //2nd array -- How many untranslated texts can be translated at a time
    //3rd array -- extra Marks earned for ALL companions
    private int[,] p_e = { { 30, 60, 80, 100 },
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
        psyche.SetValues_r(p_r);
        motivation.SetValues_r(m_r);

        psyche.SetEffectArray(p_e);
        motivation.SetEffectArray(m_e);

        psyche.SetValues_t(5);
        motivation.SetValues_t(3);
     

        timeToCompleteTask = 25f;



        CharacterSetUp("Quan");

    }

    public override string GetPsycheEffectDesc()
    {
        string effectText = "";
        switch (psyche.GetIndex())
        {
            case 0:
                effectText = "<b>Marks of Humanity Rate:</b> " + psyche.GetEffectArray(0, 0) + "%";
                break;
            case 1:
                effectText = "<b>Marks of Humanity Rate:</b> " + psyche.GetEffectArray(0, 1) + "%" + "\n" + "<b>Translation Texts Limit:</b> +" + (psyche.GetEffectArray(1, 1) - 2) + " → " + psyche.GetEffectArray(1, 1);
                break;
            case 2:
                effectText = "<b>Marks of Humanity Rate:</b> " + psyche.GetEffectArray(0, 2) + "%";
                break;
            case 3:
                effectText = "<b>Marks of Humanity Rate: Gauranteed</b>" + "\n" + "<b>Marks Earned:</b> +" + psyche.GetEffectArray(2, 3) + " addtional Marks for ALL companions";
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
                effectText = "<b>Efficiency:</b> " + psyche.GetEffectArray(0, 0) + "%" + "\n" + "<b>Translated Texts Earned:</b> " + motivation.GetEffectArray(1, 0) + "% chance for +1 extra";
                break;

            case 1:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffectArray(0, 1) + "%";
                break;

            case 2:
                effectText = "<b>Translated Texts Earned: Gauranteed +1 Extra";
                break;

            case 3:
                effectText = "<b>Efficiency:</b> " + motivation.GetEffectArray(0,3) + "%";
                break;
        }
        return effectText;
    }

    public void CompleteTask(int texts)
    {
        //the yield for untranslated -> translated is n-1
        //To be called in CompanuinUI.cs

        //Take away untranslated texts from player inventory
        player.GetComponent<Player>().SetResource(3, (-1) * texts);

        //caluclate the rewards
        int rewards = texts - 1 + GetBonusResources();

        //Add these resources to player inventory
        player.GetComponent<Player>().SetResource(4, rewards);

        CompleteTask();
    }

    protected override void UpdatePsycheEffect()
    {
        base.UpdatePsycheEffect();


        mohRate = psyche.GetEffect(1);
        MAX_translatedTexts = psyche.GetEffect(2);
        additionalMarksEarned = psyche.GetEffect(3);



    }
    protected override void UpdateMotivationEffect()
    {
        base.UpdateMotivationEffect();
        efficiency = motivation.GetEffect(1);
        extraRewardsRate = motivation.GetEffect(2);

    }

    protected override void SetDefaultValues()
    {
        insightCost = 100;
        MAX_translatedTexts = 2;
        extraRewardsRate = 0;
        base.SetDefaultValues();
    }

    private int GetBonusResources()
    {
        int numGen = Random.Range(0, 100);

        //This will always default to fail if extraRewardsRate is 0 (we are not generating a number less than 0)
        if (numGen < extraRewardsRate)
        {
            return 1;
        }
        return 0;
    }

}
