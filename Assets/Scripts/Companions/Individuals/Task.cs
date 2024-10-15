using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{

  

    //For choosing/spending resources
    private int fedValues;
    private int thresh;

    public Button decrease;
    public Button increase;

    
    //this will turn into "Redeem" for Erem after a certain amount of texts have been researched
    public Button dispatch;
    public TMP_Text dispatchBtn;

   

   
   

    public void Increases()
    {
        fedValues++;
    }

    public void Decreases()
    {
        fedValues--;
    }

    
   
}
