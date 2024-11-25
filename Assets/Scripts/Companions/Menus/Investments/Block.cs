using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public StatBlock[] stats = new StatBlock[4];
   
    public void SetUpStats(Companion comp)
    {
        

        stats[0].value.text = comp.efficiency.ToString() + "%";
        stats[1].value.text = comp.mohRate.ToString()+"%";

        int icon1 = 0;
        int icon2 = 0;

        string name1 = "";
        string name2 = "";

        string val1 = comp.specialVal1.ToString();
        string val2 = comp.specialVal2.ToString();

        switch (comp.comName)
        {
            case "Erem":
                icon1 = 4;
                icon2 = 5;
                name1 = "Study Cap.";
                name2 = "Global MoH Earned";
                break;

            case "Gwynhark":
                icon1 = 6;
                icon2 = 6;

                name1 = "Scavenging (MIN)";
                name2 = "Scavenging (MAX)";
                break;

            case "Quan":
                name1 = "Translation Cap.";
                name2 = "Global MoH Earned";

                icon1 = 3;
                icon2 = 5;
                break;
        }


        stats[2].icon.sprite = GameAssets.Instance.ResourceIcons[icon1];
        stats[2].effect.text = name1;
        stats[2].value.text = val1;

        stats[3].icon.sprite = GameAssets.Instance.ResourceIcons[icon2];
        stats[3].effect.text = name2;
        stats[3].value.text = val2;

    }

  
}
