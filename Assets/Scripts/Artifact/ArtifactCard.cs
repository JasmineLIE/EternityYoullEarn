using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactCard : MonoBehaviour
{
   
    public GameObject artifactDesc;

    //to draw from
    public string textFile;
    public string artName;

    public Image button;
    public TMP_Text nameText;
 

    //for calculating rewards when the artifact gets activated
    public int[] effectKeys;
    public int[] effectValues;

    public float timeEffect;
    // Start is called before the first frame update
   

    public virtual void DisplayInfo()
    {
        //the default is to be used by unactivated artifacts
        artifactDesc.GetComponent<ArtifactDescription>().SetDesc(artName, textFile, false, GetEffectText());
    }

    public void ClearInfo()
    {
        artifactDesc.GetComponent<ArtifactDescription>().Clear();
    }

    public string GetEffectText()
    {
        string description = ManageTextFiles.GetLineAtKey("[EFFECT]", textFile);
        description = ManageTextFiles.ReplaceText(description, effectValues[0].ToString(), "#");

        if (timeEffect > 0)
        {
            description = ManageTextFiles.ReplaceText(description, timeEffect.ToString(), "@");
        }

        return description;
    }
}
