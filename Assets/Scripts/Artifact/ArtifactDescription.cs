using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArtifactDescription : MonoBehaviour
{

    public TMP_Text title;
    public TMP_Text desc;

    public static bool isActive;

    private void Start()
    {
        Clear();
    }
    public void SendSignal(string name, string fileName)
    {
        print("Trying to send signal");
        title.text = name;
        List<string> texts = ManageTextFiles.GetLineStopAtKey("[EFFECT]", fileName);
        foreach (string text in texts)
        {
            desc.text += text + "\n\n";
        }
    }

    public void Clear()
    {
        print("We are clearing!");
        title.text = "";
        desc.text = "";
    }
}
