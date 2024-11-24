using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class CompanionUI_Menu : MonoBehaviour
{
    public CompanionUI_Btn[] btns = new CompanionUI_Btn[3];
    public CompanionUI_Bio bioMenu;
    public CompanionUI_Task taskMenu;
    public CompanionUI_Investment investMenu;

    public Block[] statBlocks = new Block[2];

   private CompanionUI_Menu_Model[] menus = new CompanionUI_Menu_Model[3];

    /*
     * 0 - Erem
     * 1 - Gwyn
     * 2 - Quan
     */
    public Companion[] comps = new Companion[3];    

    /*
     * 0 = Tasks
     * 1 = Investments
     * 2 = Bio
     */
    public int currMenu;
    public int compIndex;

    //DEBUG
    private bool debug;
    private void Start()
    {
        debug = true;
        menus[0] = taskMenu;
        menus[1] = investMenu;
        menus[2] = bioMenu;

        SetButtonIDs();
     
      
    }
    private void Update()
    {
        if (GameAssets.Instance != null && debug) {
            OpenMenu(0, 2);
            debug = false;
        }
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
        //Companion selected
        compIndex = tempIndex;

        //Menu selected
        currMenu = menu;

        //Set Companion name header and bark text
        CompanionUI_General.SetText(comps[compIndex].comName, comps[compIndex].GetBark());


        //Load in all the data for each menu
        SetUpCompanionData();

        //set button states and active menu
       for(int i = 0; i < btns.Length; i++)
        {
            if (i == menu)
            {
                btns[i].UpdateButtonState(true);
                menus[i].MenuSetActive();
               
            } else
            {
                btns[i].UpdateButtonState(false);
                menus[i].MenuSetInactive();
              
            }
        }

     
        
     
    }


    private void SetUpCompanionData()
    {
        //Set up static reference to the active companion
        CompanionUI_Menu_Model.currComp = comps[compIndex];

        //Sprites for appropriate selected companion
        bioMenu.SetImage(GameAssets.Instance.CompanionBioArt[compIndex]);
        investMenu.SetImage(GameAssets.Instance.CompanionInvestmentsArt[compIndex]);
        taskMenu.SetImage(GameAssets.Instance.CompanionTasksArt[compIndex]);

        //TASKS
        //set hint text based on who is selected
        taskMenu.hintText.text = taskMenu.compHints[compIndex];
      

        //BIO
       
        foreach (string bio in comps[compIndex].bio)
        {
            bioMenu.bioDesc.text += bio + "\n";
        }

        //INVESTMENTS

        investMenu.SetUpMotivation();
        investMenu.SetUpPsyche();

        foreach(Block blocks in statBlocks)
        {
            blocks.SetUpGlobalStats(comps[compIndex].efficiency, comps[compIndex].mohRate);
        }
    }
    
}
