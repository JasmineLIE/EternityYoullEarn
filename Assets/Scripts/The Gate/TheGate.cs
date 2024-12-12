using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheGate : MonoBehaviour
{

    private GameObject player;
    private int insightIncrement;
    public GameObject ArtifactManager;
    public GameObject feedbackPrefab;
    public AudioSource SFX;
    public bool EndState;

   
    private void Start()
    {
        EndState = false;
        ArtifactManager.GetComponent<ArtifactManager>().LoadArtifacts();
     
    }
    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        insightIncrement = player.GetComponent<Player>().saveData.GetInsightIncrementVal();
      
    }

   
    public void Clicked()
    {
        EndState = player.GetComponent<Player>().saveData.ActivatedCount == 5;
        if (EndState)
        {
            SceneManager.LoadScene("End");
        }
        SFX.clip = GameAssets.Instance.SFX[5];
        SFX.Play();
        player.GetComponent<Player>().SetResource(0, insightIncrement);
        GenMarks();
        GameObject increment = Instantiate(feedbackPrefab);
        increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" + insightIncrement;
        increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[0];
        increment.transform.SetParent(gameObject.transform);
        increment.transform.position = Input.mousePosition;

      

    }

    private void GenMarks()
    {
        int ranNum = Random.Range(1, 100);
       
        if (player.GetComponent<Player>().saveData.GetMOHIncrement() >= ranNum)
        {
            player.GetComponent<Player>().SetResource(1, 1);

            GameObject increment = Instantiate(feedbackPrefab);
            increment.GetComponent<GateIncrementFeedback>().feedback.text = "+" + 1;
            increment.GetComponent<GateIncrementFeedback>().icon.sprite = GameAssets.Instance.ResourceIcons[1];
            increment.transform.SetParent(gameObject.transform);
            increment.transform.position = Input.mousePosition;
        }
    }
   
  
}
