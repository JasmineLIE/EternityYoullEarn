using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private int insight;
    private int marksOfHumanity;
    private int crystalEbonies;
    private int textsUntrans;
    private int textsTrans;

   

    private void Awake()
    {
        //INIT
        insight = 0;
        marksOfHumanity = 0;
        crystalEbonies = 0;
        textsUntrans = 0;
        textsTrans = 0;
          
    }
       
    public void SetResource(int key, int val)
    {
   
        /**
         * (Referenced like array)
         * Insight = 0
         * Marks of Humanity = 1
         * Crystal Ebonies = 2
         * Untranslated Texts = 3
         * Translated Texts = 4
         */

      // log(n) time complexity :weary:
    
       if (key == 2)
        {
            crystalEbonies += val;
        } 
        else if (key < 2)
        {
            if (key == 1)
            {
                marksOfHumanity += val;
            } 
            else
            {
                insight += val;
            }
        } 
        else
        {
            if (key == 3)
            {
                textsUntrans += val;
            } 
            else
            {
                textsTrans += val;
            }
        }
    }

    public int GetResource(int key)
    {
        /**
         * (Referenced like array)
         * Insight = 0
         * Marks of Humanity = 1
         * Crystal Ebonies = 2
         * Untranslated Texts = 3
         * Translated Texts = 4
         */

        if (key == 2)
        {
            return crystalEbonies;
        }
        else if (key < 2)
        {
            if (key == 1)
            {
                return marksOfHumanity;
            }
            else
            {
                return insight;
            }
        }
        else
        {
            if (key == 3)
            {
                return textsUntrans;
            }
            else
            {
                return textsTrans;
            }
        }

    }
}
