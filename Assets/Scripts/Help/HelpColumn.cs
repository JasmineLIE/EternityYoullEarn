using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

public class HelpColumn : MonoBehaviour
{
    public List<HelpButton> buttons = new List<HelpButton>();
    public static int helpIndex;


    private void Start()
    {
        buttons[helpIndex].Show();
    }

    public void Exit()
    {
        helpIndex = 0;
        CustomSceneManager.ChangeScene(CustomSceneManager.CurrScene);
    }
}
