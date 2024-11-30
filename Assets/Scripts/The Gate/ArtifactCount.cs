using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactCount : MonoBehaviour
{
  
    public SaveData SaveData;
    public Image fill;
    public TMP_Text count;
    public CanvasGroup tt;

    void Start()
    {
        tt.alpha = 0;
        print("Artifact count: " + SaveData.ActivatedCount);
        fill.fillAmount = (float)SaveData.ActivatedCount / 5;
        count.text = SaveData.ActivatedCount + "/5";
    }

    public void Hover()
    {
        tt.alpha = 1;
    }

    public void HoverOut()
    {
        tt.alpha = 0;
    }
}
