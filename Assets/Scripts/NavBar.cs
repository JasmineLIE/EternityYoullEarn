using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBar : Clickable
{
    public override void Clicked()
    {
        throw new System.NotImplementedException();
        //There is no implementation currently
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
