using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    bool canExit;
    private void Start()
    {
        canExit = false;
        GameObject persistent = GameObject.FindGameObjectWithTag("Persistent");
        if(persistent != null)
        {
            Destroy(persistent);    
        }
       
        StartCoroutine(ExitWait()); 
    }

    private void Update()
    {
        if (canExit && (Input.GetKeyUp("space") || Input.GetKeyUp(KeyCode.Mouse0)))
        {
            SceneManager.LoadScene("Title");
        }
    }
    IEnumerator ExitWait()
    {
        yield return new WaitForSeconds(6f);
        canExit = true;
    }
}
