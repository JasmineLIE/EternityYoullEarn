using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    public GameObject infoScreen;
    public string fileName;
    public int imageIndex;
    public AudioSource SFX;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
        infoScreen = GameObject.FindGameObjectWithTag("Info");
    }
    public void Show()
    {
        infoScreen.GetComponent<InfoScreen>().description.text = ""; //Clear
        SFX.Play();
        string[] text = ManageTextFiles.GetAllLines(fileName);
        infoScreen.GetComponent<InfoScreen>().title.text = text[0];
        for(int i = 1; i < text.Length; i++) {
            infoScreen.GetComponent<InfoScreen>().description.text += text[i] + "\n\n";
        }

        infoScreen.GetComponent<InfoScreen>().snapshot.sprite = GameAssets.Instance.InfoSnapshots[imageIndex];


    }
}
