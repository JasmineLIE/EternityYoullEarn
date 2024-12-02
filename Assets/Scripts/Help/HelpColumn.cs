using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelpColumn : MonoBehaviour
{
    public List<HelpButton> buttons = new List<HelpButton>();
    public static int helpIndex;

    public AudioSource SFX;
    private void Start()
    {
        SFX = GetComponent<AudioSource>();
        buttons[helpIndex].Show();
    }

    public void Exit()
    {
        helpIndex = 0;
        CustomSceneManager.ChangeScene(CustomSceneManager.CurrScene);
    }
}
