using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TMP_Text timer;
    public Image timerForeground;
    public float timeRemaining;
    public float maxTime;

    private CanvasGroup cg;

    public CanvasGroup busyScreen;

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
      
    }
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            cg.alpha = 1;
            timeRemaining -= Time.deltaTime;
            timerForeground.fillAmount = timeRemaining / maxTime; //coverted to decimal value between 0 and 1
            UpdateTimer(timeRemaining);
        }  else
        {
            cg.alpha = 0;
            BusyScreenClose();
        }
    }

    public void SetTime(float max, float remaining)
    {
        maxTime = max;
        timeRemaining = remaining;
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        BusyScreenOpen();
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    
    }
    public void BusyScreenClose()
    {

        busyScreen.alpha = 0;
        busyScreen.interactable = false;
        busyScreen.blocksRaycasts = false;
    }

    public void BusyScreenOpen()
    {

        busyScreen.alpha = 1;
        busyScreen.interactable = true;
        busyScreen.blocksRaycasts = true;

     
    }

}
