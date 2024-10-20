using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public CanvasGroup cg;
    public TMP_Text status;
  

   
    protected void SetText(string stat)
    {
        status.text = stat;
    
    }
    

    public void Close()
    {
        cg.alpha = 0;
    }

    public void Open()
    {
        cg.alpha = 1;
    }
}
