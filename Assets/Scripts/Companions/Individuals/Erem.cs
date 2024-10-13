using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Erem : Companion
{

    public int MAX_translatedTexts;
    public int artifactTarget;
    public int studiedArtifacts;

    public ArtifactManager artifactManager;

    private int[] p_r= { 2, 3, 4, 5 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- MOH earn rate
    //2nd array -- Additional marks earned by companions
    //3rd array -- N/A
    private int[,] p_e = {  { 20, 40, 70, 100 }, 
                                { 0, 3, 0, 10 }, 
                                { 0, 0, 0, 0 }  };

    //1st array -- efficiency
    //2nd array -- Translated texts they can study at a time
    //3rd array -- N/A
    private int[,] m_e = {  { 10, 15, 30, 50 }, 
                                { 4, 5, 5, 6 }, 
                                { 0, 0, 0, 0 }  };

    void Start()
    {
        artifactTarget = 15;
      

        psyche.SetValues_r(p_r);
        motivation.SetValues_r(m_r);

        psyche.SetEffectArray(p_e);
        motivation.SetEffectArray(m_e);

        psyche.SetValues_t(5);
        motivation.SetValues_t(3);

        insightCost = 200;
        timeToCompleteTask = 45f;

        studiedArtifacts = saveData.GetStudiedArtifactsVal();

        CharacterSetUp("Erem");


       
    }

    

    public override string GetPsycheEffectDesc()
    {
        string effectText ="";
        switch (psyche.GetIndex())
        {
            case 0:
                effectText = "<b>Marks of Humanity Rate:</b> " + mohRate + "%" + " → " + psyche.GetEffectArray(0, 1) + "%";
                break;
            case 1:
                effectText = "<b>Marks of Humanity Rate:</b> " + mohRate + "%" + " → " + psyche.GetEffectArray(0,2) + "%" + "\n" + "<b>Marks Earned:</b> +" + psyche.GetEffectArray(1,1) + " Marks for ALL companions";
                break;
            case 2:
                effectText = "<b>Marks of Humanity Rate:</b> " + mohRate + "%" + " → " + psyche.GetEffectArray(0, 3) + "%";
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
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0, 0) + "%";
                break;
            case 1:
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0, 1) + "%" + "\n" + "<b>Study Translated Texts:</b> " + MAX_translatedTexts + " → " + motivation.GetEffectArray(1, 1);
                break;

            case 2:
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0,2)+ "%";
                break;

            case 3:
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0,3) + "%" + "\n" + "<b>Study Translated Texts:</b> " + MAX_translatedTexts + " → " + motivation.GetEffectArray(1,3);
                break;
        }
        return effectText;
    }

    protected override void SetDefaultValues()
    {
        base.SetDefaultValues();
        psyche.SetEffect(0, mohRate);
      
        MAX_translatedTexts = 3;
        motivation.SetEffect(1, MAX_translatedTexts);
        psyche.SetEffect(2, additionalMarksEarned);
       
    }

    protected override void UpdatePsycheEffect()
    {
        base.UpdatePsycheEffect();
        mohRate = psyche.GetEffect(1);
        int prevGlobalMarksEarned = additionalMarksEarned;

        additionalMarksEarned = psyche.GetEffect(2);

        SetGlobalAdditionalMarks(prevGlobalMarksEarned, additionalMarksEarned);
    }

    protected override void UpdateMotivationEffect()
    {
        base.UpdateMotivationEffect();
        efficiency = motivation.GetEffect(0);
        MAX_translatedTexts = motivation.GetEffect(1);

    }

    public void CompleteTask(int texts)
    {
        saveData.SetStudiedArtifactsVal(texts);

        player.GetComponent<Player>().SetResource(4, (-1) * texts);
        base.CompleteTask();
    }

    public bool RedeemArtifact()
    {

        //If erem has studied enough translated texts to redeem an artifact
        if (saveData.GetStudiedArtifactsVal() >= artifactTarget)
        {
            //TODO
            return true;
        }
        return false;
    }
}
