using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public enum FireMode { Alternating, Simultaneously }
    [SerializeField] FireMode fireMode;
    [SerializeField] int curAmmo = 3;
    public Weapon[] allWeapons;
    public float fireRatePerSecond = 2f;
    public bool limitedAmmo = false;
    bool limitedAmmoSwitch = false;
    float weaponTimer = 0f;
    int weaponIndex = 0;

    private void Start()
    {
        limitedAmmoSwitch = limitedAmmo;
        SetStats();
    }

    private void Update()
    {
        if(weaponTimer > 0f)
        {
            weaponTimer -= Time.deltaTime;
        }
    }

    public void SetStats()
    {
        float newShotsPerSecond = 0f;
        for (int i = 0; i < allWeapons.Length; i++)
        {
            newShotsPerSecond += allWeapons[i].GetFireRate();
        }
        if(fireMode == FireMode.Simultaneously)
        {
            newShotsPerSecond /= allWeapons.Length;
        }
        fireRatePerSecond = newShotsPerSecond;
    }

    public void Fire()
    {
        if (limitedAmmoSwitch && curAmmo > 0 || !limitedAmmoSwitch)
        {
            if (weaponTimer <= 0f)
            {
                weaponTimer = 1f / fireRatePerSecond;
                switch (fireMode)
                {
                    case FireMode.Alternating: FireAlternating(); break;
                    case FireMode.Simultaneously: FireSimultaneously(); break;
                }
                if(limitedAmmoSwitch)
                {
                    curAmmo--;
                }
            }
        }
    }

    void FireAlternating()
    {
        allWeapons[weaponIndex].FireWeapon();
        weaponIndex++;
        if(weaponIndex >= allWeapons.Length)
        {
            weaponIndex = 0;
        }
    }

    void FireSimultaneously()
    {
        foreach(Weapon weapon in allWeapons)
        {
            weapon.FireWeapon();
        }
    }
}
