using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TheGate : MonoBehaviour
{

    private GameObject player;
    private int insightIncrement;
    public GameObject ArtifactManager;
    public GameObject feedbackPrefab;

    private void Start()
    {
        ArtifactManager.GetComponent<ArtifactManager>().LoadArtifacts();
    }
    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        insightIncrement = player.GetComponent<Player>().saveData.GetInsightIncrementVal();
      
    }

   
    public void Clicked()
    {
        player.GetComponent<Player>().SetResource(0, insightIncrement);
        GameObject increment = Instantiate(feedbackPrefab);
        increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" + insightIncrement.ToString();
        increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[0];
        increment.transform.SetParent(gameObject.transform);
        increment.transform.position = Input.mousePosition;

    }

   
}
