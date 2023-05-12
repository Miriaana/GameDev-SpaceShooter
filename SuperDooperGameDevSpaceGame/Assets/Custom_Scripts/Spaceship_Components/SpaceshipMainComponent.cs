using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMainComponent : MonoBehaviour
{
    public Material[] usedMaterial;
    public Mesh[] shipMesh;
    [SerializeField] WeaponSystem primaryWeapons, secondaryWeapons;
    [SerializeField] Hull mainHull;

    private void Start()
    {
        GetComponent<Renderer>().material = usedMaterial[Random.Range(0, usedMaterial.Length)];
        GetComponent<MeshFilter>().mesh = shipMesh[Random.Range(0, shipMesh.Length)];
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
}
