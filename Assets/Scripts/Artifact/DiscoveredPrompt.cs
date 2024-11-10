using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveredPrompt : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;
    private CanvasGroup cg;

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        Close();
      
    }
    public void SetUp(string name, string fileName)
    {
        title.text = name;
        List<string> texts = ManageTextFiles.GetLineStopAtKey("[EFFECT]", fileName);
        foreach (string text in texts)
        {
            description.text += text + "\n\n\n";
        }

        Open();
    }

    private void Open()
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;

    }

    public void Close()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
        title.text = "";
        description.text = "";
    }
}
