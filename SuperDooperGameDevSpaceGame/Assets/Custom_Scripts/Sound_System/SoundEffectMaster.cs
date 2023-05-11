using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectMaster : MonoBehaviour
{
    public static SoundEffectMaster Instance;
    public GameObject soundEffectPrefab;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SpawnSoundEffect(Vector3 newLocation, AudioClip newClip, float newVolume = 1f)
    {
        SoundEffect newEffect = Instantiate(soundEffectPrefab, newLocation, transform.rotation).GetComponent<SoundEffect>();
        newEffect.PlayAudio(newLocation, newClip, newVolume);
    }
}
