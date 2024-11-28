using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public List<AudioClip> clipList;

    static int currSong;
    static float currLength;
    static float stopPoint;
  
    float downtimeSilence;
    float currDownTime;
    private void Start()
    {
        downtimeSilence = 5f;
        currDownTime = downtimeSilence;
    
        ShufflePlaylist();
    }

    private void Update()
    {
        if (currLength > 0)
        {
            
            currLength -= Time.deltaTime;
            stopPoint += Time.deltaTime;
        } else
        {
            ShufflePlaylist();
        }
        
         
        
    }

    private void ShufflePlaylist()
    {

        //if song was paused
        if (stopPoint > 0)
        {
            audioSource.clip = clipList[currSong];
            audioSource.time = stopPoint;
        } else
        {
            int song = Random.Range(0, clipList.Count);
            //if song and currSong are the same, reshuffle the value until we get something different
            while (song == currSong)
            {
                song = Random.Range(0, clipList.Count);

            }

            stopPoint = 0;
            currSong = song;

            audioSource.clip = clipList[currSong];
            audioSource.Play();
            audioSource.volume = 0;

            StartCoroutine(AudioFadeout.StartFade(audioSource, 3f, 1));

            currLength = clipList[song].length;
            currDownTime = downtimeSilence;
        }

        
    }
}
