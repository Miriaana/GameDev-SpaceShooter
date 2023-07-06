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
    [SerializeField] GameObject[] shipDisplayDummy;
    [SerializeField] private GameObject[] spaceShipPrefabs;
    [SerializeField] private TextMeshProUGUI spaceshipNameText;
    [SerializeField] private TextMeshProUGUI spaceshipSpeedText;
    [SerializeField] private TextMeshProUGUI spaceshipArmorText;
    [SerializeField] private TextMeshProUGUI spaceshipPrimaryWeaponNameText;
    [SerializeField] private TextMeshProUGUI spaceshipPrimaryWeaponDmgText;
    [SerializeField] private TextMeshProUGUI spaceshipSecondaryWeaponNameText;
    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] float speedMin, speedMax;//x value for min, y value for max
    [SerializeField] float primDamageMin, primDamageMax;//x value for min, y value for max
    public bool confirmed = false;
    bool buttonHeld = false;

    public void SetIndex(int dir)
    {
        if(!buttonHeld)
        {
            buttonHeld = true;
            index += dir;
            if(dir != 0)
            {
                ConfirmSelection(false);
            }
            if (index < 0)
            {
                index = spaceShipPrefabs.Length - 1;
            }
            else if (index > spaceShipPrefabs.Length - 1)
            {
                index = 0;
            }
            UpdateUi();
            ActivateSelectedSpaceship();
        }
        if(dir == 0)
        {
            buttonHeld = false;
        }
        CheckConfirmationState();
    }

    void CheckConfirmationState()
    {
        if(confirmed)
        {
            confirmationText.color = Color.green;
            confirmationText.text = "CONFIRMED";
        }
        else
        {
            confirmationText.color = Color.yellow;
            confirmationText.text = "Selecting...";
        }
    }

    public void UpdateUi()
    {
        SpaceshipStats stats = spaceShipPrefabs[index].GetComponent<SpaceshipMainComponent>().GetSpaceShipInfo();
        spaceshipNameText.text = stats.ShipName;
        int speedStatCount = Mathf.RoundToInt(Mathf.Lerp(1f, 10f, (stats.ShipSpeed - speedMin) / (speedMax - speedMin)));
        int armorStatCount = Mathf.RoundToInt(Mathf.Lerp(1f, 10f, 1f - 100f / (100f + stats.ShipArmor)));
        int primDmgStatCount = Mathf.RoundToInt(Mathf.Lerp(1f, 10f, (stats.ShipPrimaryWeaponDamage - primDamageMin) / (primDamageMax - primDamageMin)));
        SetStatDisplayText(spaceshipSpeedText, speedStatCount);
        SetStatDisplayText(spaceshipArmorText, armorStatCount);
        SetStatDisplayText(spaceshipPrimaryWeaponDmgText, primDmgStatCount);
        spaceshipPrimaryWeaponNameText.text = stats.ShipPrimaryWeaponName;
        spaceshipSecondaryWeaponNameText.text = stats.ShipSecondaryWeaponName;
    }

    void SetStatDisplayText(TextMeshProUGUI thisText, int count)
    {
        count = Mathf.Clamp(count, 0, 10);
        string assembledText = "";
        for (int i = 0; i < count; i++)
        {
            assembledText += "-";
        }
        thisText.text = assembledText;
    }

    void ActivateSelectedSpaceship()
    {
        for (int i = 0; i < shipDisplayDummy.Length; i++)
        {
            if(i == index)
            {
                shipDisplayDummy[i].SetActive(true);
            }
            else
            {
                shipDisplayDummy[i].SetActive(false);
            }
        }
    }

    public void ConfirmSelection(bool newState)
    {
        confirmed = newState;
        GameStateManager.Instance.StartGame();
    }

    public GameObject GetSelectedSpaceship()
    {
        return spaceShipPrefabs[index];
    }
}
