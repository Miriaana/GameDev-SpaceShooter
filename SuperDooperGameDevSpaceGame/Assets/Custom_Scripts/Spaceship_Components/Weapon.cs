using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    public float weight = 1f;
    public int teamNumber = 0;
    [SerializeField] float damage = 10f, shotsPerSecond = 1f;
    [SerializeField, Range(0f, 1f)] float armorPenetration = 0f;
    [SerializeField] GameObject instantiatedProjectile;
    [SerializeField] Transform firePoint;
    [SerializeField] float missFireDegrees = 3f, flashSize = 0.33f;
    [SerializeField] GameObject muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if(muzzleFlash != null && muzzleFlash.transform.localScale.x > 0f)
        {
            float currentSize = muzzleFlash.transform.localScale.x;
            currentSize -= Time.deltaTime;
            currentSize = Mathf.Clamp(currentSize, 0f, flashSize);
            muzzleFlash.transform.localScale = Vector3.one * currentSize;
        }
    }

    public float GetFireRate()
    {
        return shotsPerSecond;
    }

    public void FireWeapon()
    {
        var obj = Instantiate(instantiatedProjectile, firePoint.transform.position, transform.rotation);
        obj.transform.eulerAngles = firePoint.eulerAngles + firePoint.up * Random.Range(-missFireDegrees, missFireDegrees);
        obj.GetComponent<BaseDamagingProjectile>().SetStats(teamNumber, damage, armorPenetration, firePoint);
        if(muzzleFlash != null)
            muzzleFlash.transform.localScale = Vector3.one * flashSize;
    }


}
