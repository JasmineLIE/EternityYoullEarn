using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public CanvasGroup cg;
    public TMP_Text status;

    public static Task[] companionTasks = new Task[3];

   
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

    public static void UpdateText()
    {
        print("We have called to update rewards");
        foreach(Task task in companionTasks)
        {
            print("Updating rewards!");
            task.UpdateTexts();
        }
    }
}
