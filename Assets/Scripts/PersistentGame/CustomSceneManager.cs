using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour {

    public static int CurrScene;

    /**
     * 0 - Title
     * 1 - The Gate
     * 2 - Load Data
     * 3 - Companion Hub
     * 4 - Persistent Game
     */
    public static void ChangeScene(int key)
    {
        if (key > SceneManager.sceneCountInBuildSettings)
        {
            print("Invalid scene!");
        } else
        {
            CurrScene = key; 

        
            if (key == 1 || key == 3)
            {
                SceneManager.LoadScene(key);
            }

            
        }
    }
}
