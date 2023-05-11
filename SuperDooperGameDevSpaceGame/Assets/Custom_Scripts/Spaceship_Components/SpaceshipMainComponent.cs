using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMainComponent : MonoBehaviour
{
    [SerializeField] WeaponSystem primaryWeapons, secondaryWeapons;
    [SerializeField] Hull mainHull;

    public void FirePrimaryWeapons()
    {
        primaryWeapons.Fire();
    }

    public void FireSecondaryWeapons()
    {
        secondaryWeapons.Fire();
    }

    public void SetPrimaryWeaponSystemTo(WeaponSystem weaponSystem)
    {
        primaryWeapons = weaponSystem;
    }

    public void SetSecondaryWeaponSystemTo(WeaponSystem weaponSystem)
    {
        secondaryWeapons = weaponSystem;
    }
}
