using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NavBar : Clickable
{

    public TMP_Text tt_text;
     CanvasGroup tt_cg;
    RectTransform tt_rect;
    GameObject player;

    private Vector2 tt_pos;

    public float offset_y;
    public float offset_x;

    string tt_insight = "<b>Insight.</b>  Interacting with The Gate inspires your next steps.  Escape may be possible.";
    string tt_crystal_ebonies = "<b>Crystal Ebonies.</b>  A strange, crystalline flower pulsing with energy.  We could use these.";
    string tt_marks_of_humanity = "<b>Marks of Humanity.</b>  A reminder of home, of good times, of sanity.  A necessity.";
    string tt_texts_untranslated = "<b>Untranslated Texts.</b>  From a kingdom long gone.  Its texts are written in old Vietnamese.";
    string tt_texts_translated = "<b>Translated Texts.</b>  Nonsensical on its own.";
    private void Awake()
    {
  
       
        GameObject tooltip = GameObject.FindGameObjectWithTag("Tooltip");
        tt_cg = tooltip.GetComponent<CanvasGroup>();    
        tt_rect = tooltip.GetComponent<RectTransform>();   
        player = GameObject.FindGameObjectWithTag("Player");

        CloseTT();
       

    }
    public override void Clicked()
    {
        throw new System.NotImplementedException();
        //There is no implementation currently
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
    public void GoToGate()
    {
        SceneManager.LoadScene("TheGate");
    }

    public void GoToCompanionHub()
    {
        SceneManager.LoadScene("CompanionHub");
    }
}
