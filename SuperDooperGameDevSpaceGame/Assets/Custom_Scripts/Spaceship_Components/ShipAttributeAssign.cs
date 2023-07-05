using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttributeAssign : MonoBehaviour
{
    [SerializeField] WeaponSwitcher primaryWeaponSwitcher, secondaryWeaponSwitcher;
    [SerializeField] Hull hull;
    [SerializeField] SpaceshipMovement shipMovement;
    int primaryWeaponIndex = 0, secondaryWeaponIndex = 0;

    /*public void SwapPrimaryWeapon(int direction)
    {
        if(primaryWeaponIndex >= primaryWeaponSwitcher.allWeaponSystems.Length)
        {
            primaryWeaponIndex = 0;
        }
        else if(primaryWeaponIndex < 0)
        {
            primaryWeaponIndex = primaryWeaponSwitcher.allWeaponSystems.Length - 1;
        }
        primaryWeaponSwitcher.SetCurrentWeaponSystem(primaryWeaponIndex);
    }

    public void SwapSecondaryWeapon(int direction)
    {
        if (secondaryWeaponIndex >= secondaryWeaponSwitcher.allWeaponSystems.Length)
        {
            secondaryWeaponIndex = 0;
        }
        else if (secondaryWeaponIndex < 0)
        {
            secondaryWeaponIndex = secondaryWeaponSwitcher.allWeaponSystems.Length - 1;
        }
        secondaryWeaponSwitcher.SetCurrentWeaponSystem(secondaryWeaponIndex);
    }*/

    public void SwapArmorClass(int direction)
    {

    }

    public void CheckShipStats()
    {
        float weaponWeightPrim = primaryWeaponSwitcher.allWeaponSystems[primaryWeaponSwitcher.weaponIndex].allWeapons[0].weight * primaryWeaponSwitcher.allWeaponSystems[primaryWeaponSwitcher.weaponIndex].allWeapons.Length;
        float weaponWeightSeco = secondaryWeaponSwitcher.allWeaponSystems[secondaryWeaponSwitcher.weaponIndex].allWeapons[0].weight * secondaryWeaponSwitcher.allWeaponSystems[secondaryWeaponSwitcher.weaponIndex].allWeapons.Length;

    }
}
