using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMainComponent : MonoBehaviour
{
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
        playerName = $"Player {UIManager.Instance.assignmentIndex}";
        thisUiPlayer.SetName(playerName);
        thisUiPlayer.SetHealthSlider(100f);
        GetComponent<Renderer>().material = usedMaterial[Random.Range(0, usedMaterial.Length)];
        GetComponent<MeshFilter>().mesh = shipMesh[Random.Range(0, shipMesh.Length)];

        UIManager.Instance.assignmentIndex++;
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
