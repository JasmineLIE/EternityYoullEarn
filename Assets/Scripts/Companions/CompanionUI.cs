using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionUI : MonoBehaviour
{

    public TMP_Text NPC_name;
    public TMP_Text p_cost;
    public TMP_Text p_effect;
    public TMP_Text m_cost;
    public TMP_Text m_effect;

    public CanvasGroup comUI;
    public CanvasGroup TasksUI;
    public CanvasGroup BioUI;

    public ClickDetection cd;

    private string NPCName;

    public Quan quan;
    public Erem erem;
    public Gwynhark gwyn;


    private void Start()
    {
        comUI.alpha = 0;
     
    }

    public void OpenCompanionUI(string name)
    {
        NPC_name.text = name;
        NPCName = name;
        comUI.alpha = 1;
        cd.canClick = false;
        OpenTask();
    }

    public void OpenTask()
    {
        TasksUI.alpha = 1;
        BioUI.alpha = 0;
        switch (NPCName)
        {
            case "Gwynhark":
                Investments(gwyn);
                    break;

            case "Erem":
                Investments(erem);
                break;

            case "Quan":
                Investments(quan);
                break;
        }

    }

    public void Investments(Companion companion)
    {
        p_cost.text = companion.GetCurrentPsyche().ToString() + " Marks of Humanity";
        m_cost.text = companion.GetCurrentMotivation().ToString() + " Marks of Humanity";

        p_effect.text = companion.GetPsycheEffectDesc();
        m_effect.text = companion.GetMotivationEffectDesc();


    }

    public void OpenBio () {
        TasksUI.alpha = 0;
        BioUI.alpha = 1;
        switch (NPCName)
        {
            case "Gwynhark":
              
                break;

            case "Erem":
             
                break;

            case "Quan":
             
                break;
        }
    }

    public void UpgradePsyche()
    {
     
    }

    public void UpgradeMotivation()
    {
       
    }

    public void Exit()
    {
        cd.canClick = true;
        comUI.alpha = 0;

    }


   
}
