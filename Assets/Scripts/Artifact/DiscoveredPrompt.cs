using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveredPrompt : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;
    public CanvasGroup cg;
    private Animator anim;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        anim = GetComponent<Animator>();
        Close();
    }
  
    public void SetUp(string name, string fileName)
    {
        title.text = name;
        List<string> texts = ManageTextFiles.GetLineStopAtKey("[EFFECT]", fileName);
        foreach (string text in texts)
        {
            print(text);
            description.text += text + "\n\n\n";
        }

        Open();
        print("We should open");
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
