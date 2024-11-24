using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionUI_Btn : MonoBehaviour
{
    public bool isActive;
    Image img;
    public int ID;
    CompanionUI_Menu menu;
    private void Start()
    {
        img = GetComponent<Image>();
        menu = gameObject.GetComponentInParent<CompanionUI_Menu>();
    }

    public void UpdateButtonState(bool tempState)
    {
        isActive = tempState;
        if (isActive)
        {
            img.sprite = GameAssets.Instance.ButtonIcons[0];
        }
        else
        {
            img.sprite = GameAssets.Instance.ButtonIcons[1];
        }
    }

    public void SwitchMenu()
    {
        menu.OpenMenu(menu.compIndex, ID);
      
    }
}
