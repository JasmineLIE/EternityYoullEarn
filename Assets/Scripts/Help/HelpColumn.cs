using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HelpColumn : MonoBehaviour
{
    public Scrollbar scroll;
    public List<HelpButton> buttons = new List<HelpButton>();
    public static int helpIndex;

    public AudioSource SFX;
    private void Start()
    {
        SFX = GetComponent<AudioSource>();
        buttons[helpIndex].Show();
        scroll.value = 1;
    }

    public void Exit()
    {
        helpIndex = 0;
        CustomSceneManager.ChangeScene(CustomSceneManager.CurrScene);
    }
}
