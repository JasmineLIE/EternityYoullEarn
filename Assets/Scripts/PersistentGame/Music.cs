using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
   AudioSource musicSource;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        Play();
    }

    protected virtual void Play()
    {
        musicSource.Play();
    }
}
