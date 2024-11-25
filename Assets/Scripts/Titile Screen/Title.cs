using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Button play;
    public Image tiger;

    public CanvasGroup cg;
    public GameObject playButtonPos;
    public Animator anim;

    public AudioSource music;
    bool isPlaying;
    private void Start()
    {
        isPlaying = false;
    
       
        if (!SaveData.DoesSaveExist())
        {
            play.interactable = false;
        } else
        {
            play.interactable = true;
        }
    }

    private void Update()
    {
        if(!isPlaying)
        {
            
            ShowTiger();
        } 

    }
    public void Play()
    {
        StartCoroutine(PlayTransition("LOAD"));
     
    }

    public void NewGame()
    {
        StartCoroutine(PlayTransition("NEW"));
    }
   
    /*
     * The tiger fades in and our based on the distance between the cursor and the "Continue" button (The tiger wants you to release it!!!)
     */
    public void ShowTiger()
    {

        float dist = ((Vector3.Distance(playButtonPos.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) * 0.1f) - 0.5f);

        
        tiger.color = new Color(0.4245283f, 0.0531964f, 0, 1 - dist);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public IEnumerator PlayTransition(string gameType)
    {
        isPlaying = true;
        cg.interactable = false;
        tiger.color = new Color(0.4245283f, 0.0531964f, 0, 1f);
        anim.SetTrigger("Fade");

        StartCoroutine(AudioFadeout.StartFade(music, 5f, 0f));

        yield return new WaitForSeconds(5f);
        if (!SaveData.DoesSaveExist() || gameType == "NEW")
        {
            SaveData.DeleteSave();
            SceneManager.LoadScene("Intro");
        } else
        {
            SceneManager.LoadScene("LoadData");
        }
     
     
    }
}
