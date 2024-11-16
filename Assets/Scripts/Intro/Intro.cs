using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public CutsceneTree cutscene = new CutsceneTree();
    public ParticleSystem ps;
    public CanvasGroup talisman;
    bool canClick, talismanShow;

    private void Start()
    {
        talisman.alpha = 0;
        talisman.interactable = false; 
        talisman.blocksRaycasts = false;
        canClick = false;
        talismanShow = false;
        
      
        StartCoroutine(WaitForBlackScreen());
    }
    // Start is called before the first frame update


    private void Update()
    {
       
        if (Input.GetKeyUp("space") || Input.GetKeyUp(KeyCode.Mouse0) && canClick) {
            bool isCutscenePlaying = cutscene.CanTraverse();

            if (isCutscenePlaying)
            {
                cutscene.TraverseTree();
            } else
            {
                cutscene.FadeOut();

                talismanShow = true;

                ps.Stop();
            }
        }

        if (talismanShow)
        {
            talisman.alpha += Time.deltaTime;

        }

        if (talisman.alpha >=1)
        {
            talisman.interactable = true;
            talisman.blocksRaycasts = true;

        }
        
    }

  
    public IEnumerator WaitForBlackScreen()
    {
        yield return new WaitForSeconds(2f);
        canClick = true;
    }

    public void Continue()
    {
        SceneManager.LoadScene("LoadData");
    }
}