using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneTree : MonoBehaviour
{
    string[] dialogue; 
    public Animator lightAnim, blackScreenAnim;

   
    public TMP_Text skipPrompt;
    public TMP_Text cutsceneDialogue;

    public List<CutsceneNode> nodes;

    public Image[] eyes;
    float tigerCurseAlpha;
    bool tigerCurseAnim;
    int count;

    private void Start()
    {
        dialogue = ManageTextFiles.GetAllLines("Intro.txt");

        tigerCurseAnim = false;
        count = 0;
        SetUpDialogue();

        TraverseTree();
     
    }
    public void SetUpDialogue()
    {
        for(int i = 0; i < dialogue.Length; i++) {
            CutsceneNode temp = ScriptableObject.CreateInstance<CutsceneNode>();
            temp.dialogue = dialogue[i];    
            nodes.Add(temp);
        }
    
    }

    private void Update()
    {
        if (tigerCurseAnim)
        {
            tigerCurseAlpha += Time.deltaTime;
            cutsceneDialogue.color = new Color(1, 0, 0, tigerCurseAlpha);
            foreach(Image eye in eyes)
            {
                eye.color = new Color (1,0,0,tigerCurseAlpha);
            }
        }
    }

    public void TraverseTree()
    {
        //we can access more nodes
        
            cutsceneDialogue.text = nodes[count].dialogue;

            switch (count)
            {
                case 2:
                    LightPanAnimation();
                    break;
             
            }
            count++;
       
    }

    private void LightPanAnimation()
    {
        lightAnim.SetTrigger("Pan");
    }
    
    public void FadeOut()
    {
        skipPrompt.text = "TEAR THE FIRST SEAL.";
        cutsceneDialogue.color = new Color(1, 0, 0, tigerCurseAlpha);
        cutsceneDialogue.text = "FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME FREE ME";
        blackScreenAnim.SetTrigger("FadeIn");
        StartCoroutine(TigerCurseCountdonw());
    }

    public bool CanTraverse()
    {
        return count < nodes.Count;
    }

    public IEnumerator TigerCurseCountdonw()
    {
        yield return new WaitForSeconds(10f);
        tigerCurseAnim = true;
    }
}
