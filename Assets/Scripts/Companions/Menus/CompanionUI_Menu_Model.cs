using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionUI_Menu_Model : MonoBehaviour
{
    public Image img;
    public CanvasGroup menu;
    public static Companion currComp;

    private void Start()
    {
        menu = GetComponent<CanvasGroup>();   
    }

    public void MenuSetActive()
    {
        menu.alpha = 1;
        menu.interactable = true;
        menu.blocksRaycasts = true;
       
    }

  public void MenuSetInactive()
    {
        menu.alpha = 0;
        menu.interactable = false;
        menu.blocksRaycasts = false;
    }

    public void SetImage(Sprite sprite)
    {
        img.sprite = sprite;
    }

}
