using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;
    public static GameAssets Instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance;
        }
    }

    public Sprite[] ResourceIcons;

    //COMPANION MENU
    public Sprite[] ButtonIcons;

    public Sprite[] CompanionTasksArt;
    public Sprite[] CompanionInvestmentsArt;
    public Sprite[] CompanionBioArt;

    public Sprite[] InfoSnapshots;

    public Sprite[] Revelations;

    public AudioClip[] SFX;
}
