using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionUI : MonoBehaviour
{
    public CanvasGroup comUI;
    public TMP_Text NPC_name;

    private void Start()
    {
        comUI.alpha = 0;
        comUI.blocksRaycasts = false;
    }

    public void OpenCompanionUI(string name)
    {
        NPC_name.text = name;
        SetUpUI(name);
        comUI.alpha = 1;
        comUI.blocksRaycasts = true;
    }

    public void SetUpUI(string key)
    {
        switch (key)
        {
            case "Gwynhark":
                GwynharkUI();
                    break;

            case "Erem":
                EremUI();
                break;

            case "Quan":
                QuanUI();
                break;
        }
    }

    private void GwynharkUI()
    {

    }

    private void EremUI()
    {

    }

    private void QuanUI()
    {

    }

    public void Exit()
    {
        comUI.alpha = 0;
        comUI.blocksRaycasts= false;
    }
}
