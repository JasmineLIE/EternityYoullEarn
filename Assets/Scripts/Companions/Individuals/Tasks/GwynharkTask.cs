using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GwynharkTask : Task
{

    protected int fedValues2;
    protected int resourceKey2;

    public TMP_Text cbVals;
    public TMP_Text utVals;
    public TMP_Text expedition;


    private int expeditionPoints;
    public Image[] cb_counters = new Image[3];
    public Image[] untransTexts_counters = new Image[3];

    GameObject gwynhark;
    // Start is called before the first frame update
    void Start()
    {
        gwynhark = GameObject.FindGameObjectWithTag("Gwynhark");
        resourceKey = 2;
        resourceKey2 = 3;
        expeditionPoints = 3;
    }

    private void Update()
    {
        expedition.text = "Expedition Points Available: " + expeditionPoints;
    }
    public void ResetValues()
    {
       for (int i = 0; i < cb_counters.Length; i++)
        {
            cb_counters[i].color = Color.black;
            untransTexts_counters[i].color = Color.black;
        }

        expeditionPoints = 3;
        fedValues = 0;
        fedValues2 = 0;
        UpdateCBText();
        UpdateUntransText();
    }

    public void CBIncrease()
    {
        if (fedValues < expeditionPoints)
        {
            fedValues++;
            expeditionPoints--;
            AdjustCBIcons();
          
        } else
        {
            print("No more expedition points!");
        }
    }

    public void CBDecrease()
    {
        if (fedValues > 0)
        {
            fedValues--;
            expeditionPoints++;
            AdjustCBIcons();

        }
        else
        {
            print("We cannot go any lower!");
        }
    }

    public void UntransIncrease()
    {
        if (fedValues2 < expeditionPoints)
        {
            fedValues2++;
            expeditionPoints--;
            AdjustUntransIcons();
        }
        else
        {
            print("No more expedition points!");
        }
    }

    public void UntreansDecrease()
    {
        if (fedValues2 > 0)
        {
            fedValues2--;
            expeditionPoints++;
            AdjustUntransIcons();
        }
        else
        {
            print("We cannot go any lower!");
        }

    }

    public void Request()
    {
        if (expeditionPoints == 0)
        {

        } else
        {
            print("Please spend more expedition points!");
        }
    }
    private void UpdateCBText()
    {
        int temp = fedValues * gwynhark.GetComponent<Gwynhark>().MIN_resources;
        int temp2 = fedValues * gwynhark.GetComponent<Gwynhark>().MAX_resources;
        cbVals.text = "Crystal Ebonies: " + temp + " - " + temp2;

        if (fedValues == 0)
        {
            cbVals.text = "Crystal Ebonies: 0";
        }
    }

    private void UpdateUntransText()
    {
        int temp = fedValues2 * gwynhark.GetComponent<Gwynhark>().MIN_resources;
        int temp2 = fedValues2 * gwynhark.GetComponent<Gwynhark>().MAX_resources;
        cbVals.text = "Untranslated Texts: " + temp + " - " + temp2;

        if (fedValues2 == 0)
        {
            cbVals.text = "Untranslated Texts: 0";
        }
    }

    private void AdjustCBIcons()
    {
        int leftover = 1;
        for (int i = 0; i < fedValues; i++)
        {
            cb_counters[i].color = Color.white;
             leftover++;
        }
    
        if (fedValues < 2)
        {
            cb_counters[leftover].color = Color.black;
        }
       
    }

    private void AdjustUntransIcons()
    {
        int leftover = 1;
        for (int i = 0; i < fedValues2; i++)
        {
            untransTexts_counters[i].color = Color.white;
            leftover++;
        }

        if (fedValues2 < 2)
        {
            untransTexts_counters[leftover].color = Color.black;
        }
    }

   

}
