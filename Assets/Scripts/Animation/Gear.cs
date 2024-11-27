using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear : MonoBehaviour
{
    Animator animator;
    CanvasGroup cg;
    public Image parentImage;
    public int parentID; //to help us check if we need to play animation (0 = Erem, 1 = Gwyn, 2 = Quan)
    private void Start()
    {
        animator = GetComponent<Animator>();
        cg = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        switch(parentID)
        {
            case 0:
                if(BackgroundTasks.EremHasTask)
                {
                    Play();
                } else
                {
                    Stop();
                }
                break;
                case 1:

                if (BackgroundTasks.GwynHasTask)
                {
                    Play();
                }
                else
                {
                    Stop();
                }
                break;
                case 2:

                if (BackgroundTasks.QuanHasTask)
                {
                    Play();
                }
                else
                {
                    Stop();
                }
                break;


        }
    }
    public void Play()
    {
        cg.alpha = 1;
        animator.enabled = true;
        parentImage.color = Color.grey;
    }

    public void Stop()
    {
        cg.alpha = 0;
        animator.enabled = false;
        parentImage.color = Color.white;
    }
}
