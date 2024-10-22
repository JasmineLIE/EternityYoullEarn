using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompanionUI : MonoBehaviour
{
    

    public TMP_Text NPC_name;
    public TMP_Text p_cost;
    public TMP_Text p_effect;
    public TMP_Text m_cost;
    public TMP_Text m_effect;
    public TMP_Text mohAlert;

    public Button psycheButton;
    public Button motivationButton;

    public CanvasGroup comUI;
    public CanvasGroup TasksUI;
    public CanvasGroup BioUI;

    public CanvasGroup quanTask;
    public CanvasGroup eremTask;
    public CanvasGroup gwynTask;

    public ClickDetection cd;

    private string NPCName;

    public Quan quan;
    public Erem erem;
    public Gwynhark gwyn;

    public GameObject DomUI;
    public GameObject BackUI;

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
        CloseBio();
        
    
      

        TasksUI.interactable = true;
        TasksUI.alpha = 1;

        UpdateMoHAlert();
    
        switch (NPCName)
        {
           
            case "Gwynhark":
                Investments(gwyn);
          
                gwynTask.alpha = 1;
            gwynTask.transform.SetParent(DomUI.transform);
                gwynTask.interactable = true;
                eremTask.alpha = 0;
                eremTask.transform.SetParent(BackUI.transform);
                quanTask.alpha = 0;
                quan.transform.SetParent(BackUI.transform);

                Rewards.UpdateText();
                break;

            case "Erem":
                Investments(erem);
                gwynTask.alpha = 0;
                gwynTask.transform.SetParent(BackUI.transform);
                eremTask.alpha = 1;
                eremTask.transform.SetParent(DomUI.transform);
                eremTask.interactable = true;
                quanTask.alpha = 0;
                quanTask.transform.SetParent(BackUI.transform);
                Rewards.UpdateText(); 
                break;

            case "Quan":
                Investments(quan);
                gwynTask.alpha = 0;
                gwynTask.transform.SetParent(BackUI.transform);
                eremTask.alpha = 0;
                eremTask.transform.SetParent(BackUI.transform);
                quanTask.alpha = 1;
                quanTask.transform.SetParent(DomUI.transform);
                quanTask.interactable = true;
                Rewards.UpdateText();
                break;
        }

    }

    public void Investments(Companion companion)
    {
      
        if (companion.psyche.GetIndex() < companion.psyche.effect.GetLength(0))
        {
            psycheButton.enabled = true;
         
            p_cost.text = companion.GetCurrentPsyche().ToString() + " Marks of Humanity";
            p_effect.text = companion.GetPsycheEffectDesc();
        } else
        {
            p_effect.text = "No more upgrades";
            p_cost.text = "";
            psycheButton.enabled = false;
        }

        if (companion.motivation.GetIndex() < companion.motivation.effect.GetLength(0)) {
            motivationButton.enabled = true;
            m_cost.text = companion.GetCurrentMotivation().ToString() + " Marks of Humanity";


            m_effect.text = companion.GetMotivationEffectDesc();
        } else
        {
            m_effect.text = "No more upgrades";
            m_cost.text = "";
            motivationButton.enabled = false;
        }
   


    }

    public void OpenBio () {
        CloseTask();
        BioUI.interactable = true;
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
      
        //reference to address
        Companion companion = gwyn;

        switch (NPCName)
        {
            case "Gwynhark":
                companion = gwyn;
                break;
            case "Erem":
                companion = erem;
                break;

            case "Quan":
                companion = quan;
                break;
        }

        bool wasUpgradeSuccessful = companion.UpgradePsyche();

        if (wasUpgradeSuccessful)
        {
            mohAlert.text = "Available Marks of Humanity: " + companion.player.GetComponent<Player>().GetResource(1);
            companion.player.GetComponent<Player>().saveData.IncrementTotalInvestments(); //increment total number of investments
        }
        Investments(companion);
    }

   

    public void UpgradeMotivation()
    {
      
        //reference to address
        Companion companion = gwyn;

        switch (NPCName)
        {
            case "Gwynhark":
                companion = gwyn;
                break;

            case "Erem":
                companion = erem;
                break;

            case "Quan":
                companion = quan;
                break;
        }

        bool wasUpgradeSuccessful = companion.UpgradeMotivation();

        if (wasUpgradeSuccessful)
        {
            mohAlert.text = "Available Marks of Humanity: " + companion.player.GetComponent<Player>().GetResource(1);
            companion.player.GetComponent<Player>().saveData.IncrementTotalInvestments();

        }
        Investments(companion);
    }

   
    public void Exit()
    {
        cd.canClick = true;
        comUI.alpha = 0;

    }


   private void CloseBio()
    {
        BioUI.alpha = 0;
        BioUI.interactable = false;
     
    }

    private void CloseTask()
    {
        TasksUI.alpha = 0;
        TasksUI.interactable= false;
      
    }

    private void UpdateMoHAlert()
    {
        mohAlert.text = "Available Marks of Humanity: " + quan.player.GetComponent<Player>().GetResource(1);
    }
}
