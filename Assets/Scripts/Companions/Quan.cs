using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quan : Companion
{
    private int[] p_r = { 1, 2, 3, 8 };
    private int[] m_r = { 1, 3, 6, 9 };

    //1st array -- rate to earn Marks
    //2nd array -- How many untranslated texts can be translated at a time
    //3rd array -- extra Marks earned for ALL companions
    private int[,,] p_e = { { { 20, 40, 60, 100 }, { 0, 4, 4, 4 }, { 0, 0, 0, 5 } } };

    //1st array -- efficiency
    //2nd array -- Extra translated texts earned rate
    //3rd array -- N/A
    private int[,,] m_e = { {{ 10, 30, 30, 50 }, { 50, 50, 100, 100 }, { 0, 0, 0, 0 } }};


    // Start is called before the first frame update
    void Start()
    {
        psyche_r = p_r;
        motivation_r = m_r;

        psycheEffect = p_e;
        motivationEffect = m_e;

        psyche_t = 5;
        motivation_t = 3;
        CharacterSetUp("Quan");
    }

   
}
