using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Invest_Btn : MonoBehaviour
{
    Button btn;
    public AudioSource SFX;

    public TMP_Text flavourText;
    public TMP_Text nextLevelDesc;
    public TMP_Text level;
    public Image sprite;
    GameObject player;

    public int cost;
    public int currMOH;
    public TMP_Text costText;


    string flavour;
    string nextLevel;

    public Image levelBar;
    private float maxLevel;
    public float currLevel;

    private bool maxedOut;

    private void Start()
    {
        btn = GetComponent<Button>();
        //check if there are any investments left

        
        player = GameObject.FindGameObjectWithTag("Player");
        maxLevel = 2;
     
        
      SFX = GetComponent<AudioSource>();
        nextLevelDesc.color = Color.grey;

    }

    private void Update()
    {
        maxedOut = currLevel >= maxLevel;

        if (!maxedOut)
        {
            UpdateCostText();
        }
        else
        {
          
            MaxOut();
        }

    }
    public void SetUp(string flavour, string nextLvl, int tempCost, float tempCurrLevel)
    {
        flavourText.text = flavour;
        this.flavour = flavour;

        nextLevelDesc.text = nextLvl;
        
        this.nextLevel = nextLvl;

        cost = tempCost;
        currLevel = tempCurrLevel;
        level.text = (currLevel+1).ToString();


        levelBar.fillAmount = currLevel / maxLevel;

        
    }

    private void UpdateCostText()
    {
        flavourText.text = flavour;
        nextLevelDesc.text = nextLevel;


        level.text = (currLevel + 1).ToString();

        currMOH = player.GetComponent<Player>().GetResource(1);
        
        costText.text = currMOH + "/" + cost;
        nextLevelDesc.color = Color.grey;
        //if we have the correct amount of MOH or more
        if (currMOH >= cost)
        {
            btn.interactable = true;
            sprite.color = new Color(0.7568628f, 0.5882353f, 0.3411765f); //gold
            costText.color = new Color(0.7568628f, 0.5882353f, 0.3411765f);
        } else
        {
            btn.interactable = false;
            sprite.color = Color.red;
            costText.color = Color.red;
        }
        
    }

    private void MaxOut()
    {
        btn.interactable = false;
        level.text = "MAX";
        nextLevelDesc.color = new Color(0, 0, 0, 0);
        sprite.color = new Color(0, 0, 0, 0);
        costText.color = new Color(0, 0, 0, 0);

    }

}
