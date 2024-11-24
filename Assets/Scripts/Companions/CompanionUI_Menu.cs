using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class CompanionUI_Menu : MonoBehaviour
{
    public CompanionUI_Btn[] btns = new CompanionUI_Btn[3];
    public string selectedComp;

    /*
     * 0 = Tasks
     * 1 = Investments
     * 2 = Bio
     */
    public int currMenu;

    //DEBUG
    private bool debug;
    private void Start()
    {
        debug = true;
        SetButtonIDs();
     
      
    }
    private void Update()
    {
        //DEBUG -- WORKS
       // if (GameAssets.Instance != null && debug) {
           // OpenMenu("Gwyn", 0);
           // debug = false;
       // }
    }

    //Set up buttonIDs
    private void SetButtonIDs()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].ID = i;
        }
    }
    public void OpenMenu(string compName, int menu)
    {
        selectedComp = compName;
        //set button states
       for(int i = 0; i < btns.Length; i++)
        {
            if (i == menu)
            {
                btns[i].isActive = true;
            } else
            {
                btns[i].isActive = false;
            }
        }

       foreach(CompanionUI_Btn btn in btns) {
            btn.UpdateButtonState();
        }
    }

    
}
