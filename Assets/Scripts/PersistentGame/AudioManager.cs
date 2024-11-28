using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public List<AudioClip> clipList;

    static int currSong;
    static float currLength;
  
  
    float downtimeSilence;
    float currDownTime;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
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
          
        } else if (currDownTime > 0)
        {
            currDownTime -= Time.deltaTime;
        } else
        {
            ShufflePlaylist();
        }
        
         
        
    }

    private void ShufflePlaylist()
    {

        
            int song = Random.Range(0, clipList.Count);
            //if song and currSong are the same, reshuffle the value until we get something different
            while (song == currSong)
            {
                song = Random.Range(0, clipList.Count);

            }

            
            currSong = song;

            audioSource.clip = clipList[currSong];
            audioSource.Play();
            audioSource.volume = 0;

            StartCoroutine(AudioFadeout.StartFade(audioSource, 3f, 1));

            currLength = clipList[song].length;
            currDownTime = downtimeSilence;
        }

        
    }

