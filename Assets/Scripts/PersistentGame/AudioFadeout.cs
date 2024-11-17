

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeout : MonoBehaviour
{
    //This is a static method, which can be called by any script without prior reference to the class itself
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}

