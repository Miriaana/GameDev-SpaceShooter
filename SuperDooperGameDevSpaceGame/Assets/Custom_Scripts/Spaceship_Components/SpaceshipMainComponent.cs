using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMainComponent : MonoBehaviour
{
    public int Team = 0;
    public Material[] usedMaterial;
    public Mesh[] shipMesh;
    [SerializeField] WeaponSystem primaryWeapons, secondaryWeapons;
    [SerializeField] Hull mainHull;
    public string playerName;
    public int score { get; set; }
    public UIPlayer thisUiPlayer;

    private void Start()
    {
        thisUiPlayer = UIManager.Instance.uIPlayers[UIManager.Instance.assignmentIndex];
        playerName = $"{UIManager.Instance.Playernames[UIManager.Instance.assignmentIndex]}";
        thisUiPlayer.SetName(playerName);
        thisUiPlayer.SetHealthSlider(100f);
        GetComponent<MeshFilter>().mesh = shipMesh[Random.Range(0, shipMesh.Length)];
        SetMaterial(UIManager.Instance.assignmentIndex);
        UIManager.Instance.assignmentIndex++;
    }

    public void SetMaterial(int index)
    {
        GetComponent<Renderer>().material = usedMaterial[index];
    }

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

    public void OnDestroy()
    {
        GameStateManager.Instance.RemoveSpaceshipFromList(this);
    }
}
