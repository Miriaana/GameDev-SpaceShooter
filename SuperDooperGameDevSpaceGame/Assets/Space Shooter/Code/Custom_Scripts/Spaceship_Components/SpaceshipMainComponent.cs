using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipMainComponent : MonoBehaviour
{
    [SerializeField] private string spaceshipName;
    [SerializeField] WeaponSystem primaryWeapons, secondaryWeapons;
    public Hull mainHull;
    public int Team = 0;
    public Material[] usedMaterial;
    public SpaceshipMovement ShipMovement;
    public string playerName;
    public int score;
    public UIPlayer thisUiPlayer;
    float ammoCharge = 0f;

    private void Start()
    {
        thisUiPlayer = UIManager.Instance.uIPlayers[UIManager.Instance.assignmentIndex];
        playerName = $"{UIManager.Instance.Playernames[UIManager.Instance.assignmentIndex]}";
        thisUiPlayer.SetName(playerName);
        thisUiPlayer.SetHealthSlider(100f);
        SetMaterial(UIManager.Instance.assignmentIndex);
        UIManager.Instance.assignmentIndex++;
    }

    private void Update()
    {
        thisUiPlayer.UpdateScore(score);
        thisUiPlayer.UpdateAmmo(secondaryWeapons.curAmmo, ammoCharge);
        if(GameStateManager.Instance.currentState == GameStateManager.GameState.Bossfight)
        {
            AddAmmoCharge(Time.deltaTime * 0.5f);
        }
    }

    public void MoveShip(Vector2 direction)
    {
        ShipMovement.MoveShip(ShipMovement.SteerHor(direction.x) + ShipMovement.SteerVert(direction.y));
    }

    public SpaceshipStats GetSpaceShipInfo()
    {
        return new SpaceshipStats(spaceshipName, ShipMovement.curMovementSpeed, Mathf.RoundToInt(mainHull.armor), primaryWeapons.WeaponName, Mathf.RoundToInt(primaryWeapons.GetWeaponDps()), secondaryWeapons.WeaponName);
    }

    public void SetMaterial(int index)
    {
        GetComponent<Renderer>().material = usedMaterial[index];
    }

    public void FirePrimaryWeapons()
    {
        primaryWeapons.Fire(this);
    }

    public void FireSecondaryWeapons()
    {
        if (secondaryWeapons.curAmmo > 0)
        {
            secondaryWeapons.Fire(this);
        }
    }

    public void AddAmmoCharge(float amount)
    {
        ammoCharge += amount;
        if(ammoCharge >= 5)
        {
            ammoCharge -= 5;
            secondaryWeapons.curAmmo++;
        }
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
