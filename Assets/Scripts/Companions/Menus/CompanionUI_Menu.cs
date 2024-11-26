using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class CompanionUI_Menu : MonoBehaviour
{
  
    public CompanionUI_Bio bioMenu;
    public CompanionUI_Task taskMenu;
    public CompanionUI_Investment investMenu;

    public CompanionUI_General genUI;



    public Block[] statBlocks = new Block[2];
    public CompanionUI_Btn[] btns = new CompanionUI_Btn[3];
    private CompanionUI_Menu_Model[] menus = new CompanionUI_Menu_Model[3];

    /*
     * 0 - Erem
     * 1 - Gwyn
     * 2 - Quan
     */
    public static Companion[] comps = new Companion[3];

    /*
      * 0 - Erem
      * 1 - Gwyn
      * 2 - Quan
      */
    public Tasks[] compTasks = new Tasks[3];

    public int currMenu;
    public static int compIndex;

   
 
    private void Start()
    {
       
        menus[0] = taskMenu;
        menus[1] = investMenu;
        menus[2] = bioMenu;

        GameObject erem = GameObject.FindGameObjectWithTag("Erem");
        GameObject gwyn = GameObject.FindGameObjectWithTag("Gwynhark");
        GameObject Quan = GameObject.FindGameObjectWithTag("Quan");

        comps[0] = erem.GetComponent<Erem>();
        comps[1] = gwyn.GetComponent<Gwynhark>();
        comps[2] = Quan.GetComponent<Quan>();
        
        SetButtonIDs();
        genUI.Close();
      
    }

   
    public void EremMenu()
    {
        OpenMenu(0, 0);
    }
    public void GwynharkMenu()
    {
        OpenMenu(1, 0);
    }

    public void QuanMenu()
    {
        OpenMenu(2, 0);
    }
   

    //Set up buttonIDs
    private void SetButtonIDs()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].ID = i;
        }
    }
    public void OpenMenu(int tempIndex, int menu)
    {
        //make menu visible
        genUI.Open();

        //Companion selected
        compIndex = tempIndex;

        //Menu selected
        currMenu = menu;

        //we need to only do this once when it is initially caled
        //Load in all the data for each menu
        SetUpCompanionData();

        //Set Companion name header and bark text
        genUI.SetText(comps[compIndex].comName, comps[compIndex].GetBark());

        SwitchMenu(currMenu);
    
   
        
     
    }


    public void SwitchMenu(int menu)
    {
        
        
        //set button states and active menu
        for (int i = 0; i < btns.Length; i++)
        {
            if (i == menu)
            {
                btns[i].UpdateButtonState(true);
                menus[i].MenuSetActive();

            }
            else
            {
                btns[i].UpdateButtonState(false);
                menus[i].MenuSetInactive();

            }
        }

    }
    private void SetUpCompanionData()
    {
        //Set up static reference to the active companion

     

        //Sprites for appropriate selected companion
        bioMenu.SetImage(GameAssets.Instance.CompanionBioArt[compIndex]);
        investMenu.SetImage(GameAssets.Instance.CompanionInvestmentsArt[compIndex]);
        taskMenu.SetImage(GameAssets.Instance.CompanionTasksArt[compIndex]);

        //TASKS
        //set hint text based on who is selected
        taskMenu.hintText.text = taskMenu.compHints[compIndex];

        //Open up the correct task
        for(int i = 0; i < compTasks.Length; i++) {
            if (i == compIndex)
            {
                compTasks[i].Open();
            } else
            {
                compTasks[i].Close();
            }

            //set up info
        
            compTasks[i].SetUp(comps[i].insightCost);
        }


        //BIO
        bioMenu.bioDesc.text = ""; //clear first
        foreach (string bio in comps[compIndex].bio)
        {
            bioMenu.bioDesc.text += bio + "\n\n";
        }

        //INVESTMENTS
        investMenu.SetUpMotivation();
        investMenu.SetUpPsyche();
        investMenu.title.text = investMenu.titles[compIndex];

        foreach(Block blocks in statBlocks)
        {
            blocks.SetUpStats(comps[compIndex]);
        }
    }

    
}
