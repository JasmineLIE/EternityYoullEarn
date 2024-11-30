using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public Camera myCam;
    public bool canClick;
 

    private void Awake()
    {
        canClick = true;
    
    }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            //get mouse position
            Vector3 mousePos = Input.mousePosition;
            Ray myRay = myCam.ScreenPointToRay(mousePos);

            RaycastHit raycastHit;
            bool weHitSomething = Physics.Raycast(myRay, out raycastHit);

            if (weHitSomething && canClick)
            {
                raycastHit.transform.GetComponent<Clickable>().Clicked();
            }

          
        }
     
    }


}
