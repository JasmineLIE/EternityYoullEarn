using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene("LoadData");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
