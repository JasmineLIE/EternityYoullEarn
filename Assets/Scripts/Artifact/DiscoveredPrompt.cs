using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveredPrompt : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;
    public Image icon;
    private CanvasGroup cg;

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        Close();
      
    }
    public void SetUp(string name, string desc, Sprite img)
    {
        title.text = name;
        description.text = desc;
        icon.sprite = img;
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
   
    }
}
