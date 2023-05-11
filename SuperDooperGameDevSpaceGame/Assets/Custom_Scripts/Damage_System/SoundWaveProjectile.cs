using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveProjectile : BaseDamagingProjectile
{
    [SerializeField] float sizeIncreaseOverTime = 1f;
    float soundEffectTimeOut = 0.1f, soundEffectTimer = 0f;

    protected override void ProjectileFlight()
    {
        base.ProjectileFlight();
        transform.localScale += Vector3.one * Time.deltaTime * sizeIncreaseOverTime;
        if(soundEffectTimer > 0f)
        {
            soundEffectTimer -= Time.deltaTime;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DestroyableObject>() != null)
        {
            other.GetComponent<DestroyableObject>().DamageHull(damage * Time.deltaTime, armorPenetrationRatio);
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, other.ClosestPoint(transform.position), transform.rotation);
                if(soundEffectTimer <= 0f)
                {
                    SoundEffectMaster.Instance.SpawnSoundEffect(transform.position, deathSound, 0.25f);
                    soundEffectTimer = soundEffectTimeOut;
                }
            }
        }
    }
}
