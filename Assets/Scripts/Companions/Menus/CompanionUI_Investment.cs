using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionUI_Investment : CompanionUI_Menu_Model
{
    public Invest_Btn motivation;
    public Invest_Btn psyche;

   
    
    // Start is called before the first frame update
   
    public void SetUpMotivation()
    {
        motivation.SetUp(currComp.motivation.flavourText[currComp.motivation.GetIndex()],
                            currComp.GetMotivationEffectDesc(),
                            currComp.GetCurrentMotivation(),
                            currComp.motivation.GetIndex()
                            ) ;
    }

    public void UpgradeMotivation()
    {
        bool wasUpgradeSuccessful = currComp.UpgradeMotivation();
        if (wasUpgradeSuccessful)
        {
            currComp.player.GetComponent<Player>().saveData.IncrementTotalInvestments(); //for one of the revelations
            SetUpMotivation();
        } else
        {
            print("Do not have enough MoH to upgrade!");
        }

    }

    public void SetUpPsyche()
    {
        psyche.SetUp(currComp.psyche.flavourText[currComp.psyche.GetIndex()],
                       currComp.GetPsycheEffectDesc(),
                       currComp.GetCurrentPsyche(),
                       currComp.psyche.GetIndex()
                       );
    }

    public void UpgradePsyche()
    {
        bool wasUpgradeSuccessful = currComp.UpgradePsyche();

        if (wasUpgradeSuccessful)
        {
            currComp.player.GetComponent<Player>().saveData.IncrementTotalInvestments(); //increment total number of investments
            SetUpPsyche();
        } else
        {
            print("Do not have enough MoH to upgrade!");
        }
    }

  
}
