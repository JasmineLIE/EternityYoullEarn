using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavBar : Clickable
{

    public CanvasGroup alert;
    


    public TMP_Text tt_text;
     CanvasGroup tt_cg;
    RectTransform tt_rect;


  
    public float offset_y;
    public float offset_x;

    string tt_insight = "<b>Insight.</b>  Interacting with The Gate inspires your next steps.  Used to command your companions.";
    string tt_crystal_ebonies = "<b>Crystal Ebonies.</b>  A strange, crystalline flower pulsing with energy.  Obtained by sending Gwynhark on expeditions.  Used to activate artifacts.";
    string tt_marks_of_humanity = "<b>Marks of Humanity.</b>  A reminder of home, of good times, of sanity.  Used to upgrade your companions' abilities.";
    string tt_texts_untranslated = "<b>Untranslated Texts.</b>  From a kingdom long gone.  Its texts are written in old Vietnamese.  Obtained by sending Gwynhark on expeditions.  Can be translated by Quan.";
    string tt_texts_translated = "<b>Translated Texts.</b>  Nonsensical on its own.  Can be converted into artifacts by Erem.";

    public Animator animator;
    public Animator sweep;

    public TMP_Text transitionButton_text;
    Color amber = new Color(0.9058824f, 0.3254902f, 0.1647059f, 1f);
    Color turqoise = new Color(0.3294118f, 0.454902f, 0.4745098f, 1f);
    public Image moon;

    public Button TransitionButton;
    public GameObject screenBlocker;

    private void Awake()
    {
       
        GameObject tooltip = GameObject.FindGameObjectWithTag("Tooltip");
        tt_cg = tooltip.GetComponent<CanvasGroup>();    
        tt_rect = tooltip.GetComponent<RectTransform>();   
     
        CloseTT();
       

    }

    private void Start()
    {
        screenBlocker.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        screenBlocker.GetComponent<Image>().raycastTarget = false;
     if (CustomSceneManager.CurrScene == 3)
        {
            animator.SetTrigger("Idle2");
            transitionButton_text.text = "COMPANION HUB";
            moon.color = turqoise;
        }
    }
    public override void Clicked()
    {
        throw new System.NotImplementedException();
        //There is no implementation currently
    }

    private void Update()
    {
        if (CustomSceneManager.CurrScene==1)
        {
            if (BackgroundTasks.CanCollect)
            {
                alert.alpha = 1;
            } else
            {
                alert.alpha = 0;
            }
        } else
        {
            alert.alpha = 0;
        } 

       
    }
    private void OpenTT()
    {

        Vector2 mousePos = Input.mousePosition;
        mousePos.x += offset_x;
        mousePos.y += offset_y;
        tt_rect.position = mousePos;

        tt_cg.alpha = 1;
    }

    public void CloseTT()
    {
        tt_cg.alpha = 0;
    }

    public void InsightTT()
    {
      
        OpenTT();
        tt_text.text = tt_insight;
    }

    public void MarksOfHumanityTT()
    {
        OpenTT();
        tt_text.text = tt_marks_of_humanity;
    }

    public void CrystalEboniesTT()
    {
        OpenTT();
        tt_text.text = tt_crystal_ebonies;
    }

    public void UntransTextsTT()
    {
        OpenTT();
        tt_text.text = tt_texts_untranslated;
    }

    public void TransTextsTT()
    {
        OpenTT();
        tt_text.text = tt_texts_translated;
    }
    public void SwitchScenes()
    {
        screenBlocker.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
        screenBlocker.GetComponent<Image>().raycastTarget = true;
        
        if (CustomSceneManager.CurrScene == 1)
        {
           
            animator.SetTrigger("CompanionHubTrans");
          
           
            moon.color = turqoise;
           StartCoroutine(ChangeScene(3));

        }  if (CustomSceneManager.CurrScene == 3)
        {
          
            animator.SetTrigger("TheGateTrans");
       
          
            moon.color = amber;
            StartCoroutine(ChangeScene(1));
        }
        sweep.SetTrigger("Sweep");
        TransitionButton.interactable = false;

    }

 
   public void OpenHelp()
    {

        SceneManager.LoadScene("Help");

    }

    IEnumerator ChangeScene(int key) {
        screenBlocker.SetActive(true);
        screenBlocker.GetComponent<Image>().raycastTarget = true;
        screenBlocker.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);

  
        

        if (key == 1)
        {
            yield return new WaitForSeconds(0.5f);
            transitionButton_text.text = "THE GATE";
        } else
        {
            yield return new WaitForSeconds(0.6f);
            transitionButton_text.text = "COMPANION HUB";
        }
        print("moving to companion hub!");
        yield return new WaitForSeconds(1f);
        CustomSceneManager.ChangeScene(key);
    }
}
