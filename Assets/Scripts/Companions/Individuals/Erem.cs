using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Erem : Companion
{

    


    public int MAX_translatedTexts;
    public int artifactTarget;
    public int studiedArtifacts;
 

    

    private int[] p_r= { 2, 3, 4, 5 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- MOH earn rate
    //2nd array -- Additional marks earned by companions
    //3rd array -- N/A
    private int[,] p_e = {  { 40, 60, 70, 100 }, 
                                { 0, 3, 3, 10 }, 
                                { 0, 0, 0, 0 }  };

    //1st array -- efficiency
    //2nd array -- Translated texts they can study at a time
    //3rd array -- N/A
    private int[,] m_e = {  { 0, 15, 30, 50 }, 
                                { 3, 5, 6, 8 }, 
                                { 0, 0, 0, 0 }  };
    private void Awake()
    {
        artifactTarget = 10;



        psyche.SetValues_r(p_r);
        motivation.SetValues_r(m_r);

        psyche.SetEffectArray(p_e);
        motivation.SetEffectArray(m_e);

        psyche.SetValues_t(5);
        motivation.SetValues_t(3);

        insightCost = 150;
        timeToCompleteTask = 40f;

        studiedArtifacts = saveData.GetStudiedArtifactsVal();

        CharacterSetUp("Erem");

        specialVal1 = MAX_translatedTexts;
        specialVal2 = psyche.GetEffectArray(1, psyche.GetIndex());

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
                effectText = "<b>Marks of Humanity Rate: Gauranteed</b>" + "\n" + "<b>Marks Earned:</b> +" + psyche.GetEffectArray(1, 3) + " Marks for ALL companions";
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

            case 1:
            case 2:
            case 3:
                effectText = "<b>Efficiency:</b> " + efficiency + "%" + " → " + motivation.GetEffectArray(0, motivation.GetIndex()+1) + "%" + "\n" + "<b>Study Translated Texts:</b> " + MAX_translatedTexts + " → " + motivation.GetEffectArray(1,motivation.GetIndex()+1);
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
        if (psyche.GetIndex() > 0)
        {
            int prevGlobalMarksEarned = additionalMarksEarned;
            base.UpdatePsycheEffect();
            additionalMarksEarned = psyche.GetEffect(1);

            SetGlobalAdditionalMarks(prevGlobalMarksEarned, additionalMarksEarned);
        }

        base.UpdatePsycheEffect();
        mohRate = psyche.GetEffect(0);
        specialVal2 = psyche.GetEffectArray(1, psyche.GetIndex());

    }

    protected override void UpdateMotivationEffect()
    {
        base.UpdateMotivationEffect();
        efficiency = motivation.GetEffect(0);
        MAX_translatedTexts = motivation.GetEffect(1);
        specialVal1 = MAX_translatedTexts;
       


    }

    public void CompleteTask(int texts)
    {
        saveData.SetStudiedArtifactsVal(texts);
        studiedArtifacts = saveData.GetStudiedArtifactsVal();
   

     
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

    public override void CompleteTask()
    {
        base.CompleteTask();
     
    }

    public bool ArtifactGoalMet()
    {

       if (studiedArtifacts >= artifactTarget)
        {
            print("so true");
        }
        return studiedArtifacts >= artifactTarget;
    }


}
