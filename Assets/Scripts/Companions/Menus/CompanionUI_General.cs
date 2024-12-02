using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionUI_General : MonoBehaviour
{
    public TMP_Text compName;
    public  TMP_Text bark;
    public CanvasGroup menuCG;
    AudioSource SFX;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
    }
    public void Close()
    {
        menuCG.alpha = 0;
        menuCG.interactable = false;
        menuCG.blocksRaycasts = false;
        SFX.clip = GameAssets.Instance.SFX[1];
        SFX.Play();
    }

   public void SetText(string name, string tempBark)
    {
        compName.text = name;
        bark.text = tempBark;   
    }


    public void Open()
    {
        menuCG.alpha = 1;
        menuCG.interactable = true;
        menuCG.blocksRaycasts = true;
      
    }

   


}
