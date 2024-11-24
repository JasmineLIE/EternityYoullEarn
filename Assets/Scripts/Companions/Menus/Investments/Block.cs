using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public StatBlock[] stats = new StatBlock[4];
   
    public void SetUpGlobalStats(int efficiency, int MOH)
    {
        stats[0].value.text = efficiency.ToString();
        stats[1].value.text = MOH.ToString(); 
    
    }

    public void SetUpSpecialStats(int icon1, string name1, int value1, int icon2, string name2, int value2)
    {
        stats[2].icon.sprite = GameAssets.Instance.ResourceIcons[icon1];
        stats[2].effect.text = name1;
        stats[2].value.text = value1.ToString();

        stats[3].icon.sprite = GameAssets.Instance.ResourceIcons[icon2];
        stats[3].effect.text = name2;
        stats[3].value.text = value2.ToString();
    }
}
