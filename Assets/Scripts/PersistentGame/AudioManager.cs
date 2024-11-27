using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public List<AudioClip> clipList;

    int currSong;
    float currLength;
    float downtimeSilence;
    float currDownTime;
    private void Start()
    {
        downtimeSilence = 10f;
        currDownTime = downtimeSilence;
        ShufflePlaylist();
    }

    private void Update()
    {
        if (currLength > 0)
        {
            currLength -= Time.deltaTime;
        } else
        {
            ShufflePlaylist();
        }
    }

    private void ShufflePlaylist()
    {
        int song = 0;
        //if song and currSong are the same, reshuffle the value until we get something different
        while(song == currSong)
        {
            song = Random.Range(0, clipList.Count);

        }

        audioSource.clip = clipList[song];  
        currLength = clipList[song].length; 

    }
}
