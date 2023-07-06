using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public string WeaponName;
    public enum FireMode { Alternating, Simultaneously }
    [SerializeField] FireMode fireMode;
    public int curAmmo = 3;
    public Weapon[] allWeapons;
    public float fireRatePerSecond = 0f;
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
        fireRatePerSecond = GetFireRate();
    }

    public float GetFireRate()
    {
        float newShotsPerSecond = 0f;
        for (int i = 0; i < allWeapons.Length; i++)
        {
            newShotsPerSecond += allWeapons[i].GetFireRate();
        }
        if (fireMode == FireMode.Simultaneously)
        {
            newShotsPerSecond /= allWeapons.Length;
        }
        return newShotsPerSecond;
    }

    public void Fire(SpaceshipMainComponent assocShip)
    {
        if (limitedAmmoSwitch && curAmmo > 0 || !limitedAmmoSwitch)
        {
            if (weaponTimer <= 0f)
            {
                weaponTimer = 1f / fireRatePerSecond;
                switch (fireMode)
                {
                    case FireMode.Alternating: FireAlternating(assocShip); break;
                    case FireMode.Simultaneously: FireSimultaneously(assocShip); break;
                }
                if(limitedAmmoSwitch)
                {
                    curAmmo--;
                }
            }
        }
    }

    public float GetWeaponDps()
    {
        int weaponCount = allWeapons.Length;
        float singleWeaponDmg = allWeapons[0].damage * (1f + allWeapons[0].armorPenetration);
        switch(fireMode)
        {
            case FireMode.Alternating: return GetFireRate() * singleWeaponDmg;
            case FireMode.Simultaneously: return GetFireRate() * weaponCount * singleWeaponDmg;
        }
        return 0;
    }

    void FireAlternating(SpaceshipMainComponent assocShip)
    {
        allWeapons[weaponIndex].FireWeapon(assocShip);
        weaponIndex++;
        if(weaponIndex >= allWeapons.Length)
        {
            weaponIndex = 0;
        }
    }

    void FireSimultaneously(SpaceshipMainComponent assocShip)
    {
        foreach(Weapon weapon in allWeapons)
        {
            weapon.FireWeapon(assocShip);
        }
    }
}
