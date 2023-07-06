using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public enum SystemType { Primary, Secondary }
    public SystemType setsThisWeaponSystem;
    public WeaponSystem[] allWeaponSystems;
    [SerializeField] SpaceshipMainComponent mainComponent;
    [HideInInspector] public int weaponIndex = 0;

    private void Start()
    {
        SetCurrentWeaponSystem(Random.Range(0, allWeaponSystems.Length));
    }

    public void SetCurrentWeaponSystem(int index = 0)
    {
        weaponIndex = index;
        switch(setsThisWeaponSystem)
        {
            case SystemType.Primary:
                mainComponent.SetPrimaryWeaponSystemTo(allWeaponSystems[weaponIndex]); 
                break;
            case SystemType.Secondary:
                mainComponent.SetSecondaryWeaponSystemTo(allWeaponSystems[weaponIndex]);
                break;
        }
        for (int i = 0; i < allWeaponSystems.Length; i++)
        {
            if(i == weaponIndex)
            {
                allWeaponSystems[i].gameObject.SetActive(true);
            }
            else
            {
                allWeaponSystems[i].gameObject.SetActive(false);
            }
        }
    }
}
