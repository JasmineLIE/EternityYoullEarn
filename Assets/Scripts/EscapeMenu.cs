using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public bool paused;
    CanvasGroup cg;
    AudioSource audioSource;
    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        Off();
        paused = false;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           
            if (!paused)
            {
                paused = true;
                On();
                Time.timeScale = 0;
            } else
            {
                paused = false;
                Off();
                Time.timeScale = 1;
            }
            audioSource.Play();
        }
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void ExitToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
    public void On()
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void Off()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
