using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GateIncrementFeedback : MonoBehaviour
{
    public TMP_Text feedback;
    
    private void Start()
    {
       
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        Vector3 temp = new Vector3(feedback.rectTransform.localPosition.x, feedback.rectTransform.localPosition.y + 1, feedback.rectTransform.localPosition.z);
        feedback.rectTransform.localPosition = temp;
        feedback.alpha -= Time.deltaTime;
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
