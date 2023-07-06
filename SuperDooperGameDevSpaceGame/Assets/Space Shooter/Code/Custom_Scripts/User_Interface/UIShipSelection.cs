using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using System.Runtime.InteropServices.WindowsRuntime;

public class UIShipSelection : MonoBehaviour
{
    private int index;
    [SerializeField] private GameObject[] spaceShipPrefabs;
    [SerializeField] private TextMeshProUGUI spaceshipNameText;
    [SerializeField] private TextMeshProUGUI spaceshipArmorText;
    [SerializeField] private TextMeshProUGUI spaceshipPrimaryWeaponText;
    [SerializeField] private TextMeshProUGUI spaceshipSecondaryWeaponText;
    [SerializeField] private TextMeshProUGUI spaceshipPrimaryWeaponDmgText;
    [SerializeField] private TextMeshProUGUI spaceshipSecondaryWeaponDmgText;

    public void SetIndex(int dir)
    {
        index += dir;
        if(index < 0)
        {
            index = spaceShipPrefabs.Length - 1;
        }
        else if(index > spaceShipPrefabs.Length - 1)
        {
            index = 0;
        }
        UpdateUi();
    }

    public void UpdateUi()
    {
        SpaceshipStats stats = spaceShipPrefabs[index].GetComponent<SpaceshipMainComponent>().GetSpaceShipInfo();
        spaceshipNameText.text = stats.ShipName;
        spaceshipArmorText.text = stats.ShipArmor.ToString();
        spaceshipPrimaryWeaponText.text = stats.ShipPrimaryWeaponName;
        spaceshipPrimaryWeaponDmgText.text = stats.ShipPrimaryWeaponDamage.ToString();
        spaceshipSecondaryWeaponText.text = stats.ShipSecondaryWeaponName;
        spaceshipSecondaryWeaponDmgText.text = stats.ShipSecondaryWeaponDamage.ToString();
    }

    public GameObject GetSelectedSpaceship()
    {
        return spaceShipPrefabs[index];
    }
}
