using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionUI_Investment : CompanionUI_Menu_Model
{
    public Invest_Btn motivation;
    public Invest_Btn psyche;
    public TMP_Text title;
    public string[] titles = new string[3];
    public Block[] blocks = new Block[2];

    private void Start()
    {
        titles[0] = "THE ARCHIVIST";
        titles[1] = "THE EXPLORER";
        titles[2] = "THE TRANSLATOR";
    }

    // Start is called before the first frame update

 
    public void SetUpMotivation()
    {
        motivation.SetUp(CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].motivation.flavourText[CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].motivation.GetIndex()],
                           CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetMotivationEffectDesc(),
                            CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetCurrentMotivation(),
                          CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].motivation.GetIndex()
                             ) ;
    }

    public void UpgradeMotivation()
    {
        bool wasUpgradeSuccessful = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].UpgradeMotivation();
        if (wasUpgradeSuccessful)
        {
            CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().saveData.IncrementTotalInvestments(); //for one of the revelations
            SetUpMotivation();

            foreach(Block tempBlock in blocks)
            {
                tempBlock.SetUpStats(CompanionUI_Menu.comps[CompanionUI_Menu.compIndex]);
            }

            motivation.SFX.clip = GameAssets.Instance.SFX[0];
            motivation.SFX.Play();
        } else
        {
            motivation.SFX.clip = GameAssets.Instance.SFX[2];
            motivation.SFX.Play();
          
        }

    }

    public void SetUpPsyche()
    {
        psyche.SetUp(CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].psyche.flavourText[CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].psyche.GetIndex()],
                       CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetPsycheEffectDesc(),
                       CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].GetCurrentPsyche(),
                       CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].psyche.GetIndex()
                       );
    }

    public void UpgradePsyche()
    {
        bool wasUpgradeSuccessful = CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].UpgradePsyche();

        if (wasUpgradeSuccessful)
        {
            CompanionUI_Menu.comps[CompanionUI_Menu.compIndex].player.GetComponent<Player>().saveData.IncrementTotalInvestments(); //increment total number of investments
            SetUpPsyche();

            foreach (Block tempBlock in blocks)
            {
                tempBlock.SetUpStats(CompanionUI_Menu.comps[CompanionUI_Menu.compIndex]);
            }


            psyche.SFX.clip = GameAssets.Instance.SFX[0];
            psyche.SFX.Play();

        } else
        {
         
            psyche.SFX.clip = GameAssets.Instance.SFX[2];
            psyche.SFX.Play();

        }
    }

  
}
