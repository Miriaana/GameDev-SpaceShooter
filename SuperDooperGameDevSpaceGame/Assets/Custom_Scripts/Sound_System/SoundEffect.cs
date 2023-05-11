using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAudio(Vector3 newLocation, AudioClip newClip, float newVolume)
    {
        transform.position = newLocation;
        if(source == null)
        {
            source = GetComponent<AudioSource>();
        }
        source.clip = newClip;
        source.volume = newVolume;
        source.Play();
    }
}
