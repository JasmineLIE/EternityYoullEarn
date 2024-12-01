using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    public GameObject infoScreen;
    public string fileName;
    public int imageIndex;

    private void Start()
    {
        infoScreen = GameObject.FindGameObjectWithTag("Info");
    }
    public void Show()
    {
        string[] text = ManageTextFiles.GetAllLines(fileName);
        infoScreen.GetComponent<InfoScreen>().title.text = text[0];
        infoScreen.GetComponent<InfoScreen>().description.text = text[1];
        infoScreen.GetComponent<InfoScreen>().snapshot.sprite = GameAssets.Instance.InfoSnapshots[imageIndex];


    }
}
