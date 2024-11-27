using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GateIncrementFeedback : MonoBehaviour
{
    public TMP_Text feedback;
    public Image icon;
    CanvasGroup cg;
    
    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 1f;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        StartCoroutine(Destroy());
    }

    private void Update()
    {
        Vector3 temp = new Vector3(feedback.rectTransform.localPosition.x, feedback.rectTransform.localPosition.y + 1, feedback.rectTransform.localPosition.z);
        feedback.rectTransform.localPosition = temp;
        cg.alpha -= Time.deltaTime;
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
