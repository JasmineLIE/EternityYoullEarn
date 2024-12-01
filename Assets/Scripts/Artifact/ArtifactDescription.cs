using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public void SetDesc(string name, string fileName, bool includeEffect, string additionalText)
    {

        title.text = name;
        List<string> texts;
        texts = ManageTextFiles.GetLineStopAtKey("[EFFECT]", fileName);

      
    
        foreach (string text in texts)
        {
            desc.text += text + "\n\n\n";
        }

        if (includeEffect)
        {
            desc.text += "<color=\"grey\">" + additionalText;
        }
    }

    public void Clear()
    {
        title.text = "";
        desc.text = "";
    }
}
