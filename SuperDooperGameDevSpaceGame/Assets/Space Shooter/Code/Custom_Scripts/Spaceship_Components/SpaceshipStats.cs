using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpaceshipStats
{
	public string ShipName;
	public float ShipSpeed;
	public float ShipArmor;
	public string ShipPrimaryWeaponName;
	public float ShipPrimaryWeaponDamage;
	public string ShipSecondaryWeaponName;

    public SpaceshipStats(string name, float speed, float armor, string primaryWeaponName, float primaryWeaponDamage, string secondaryWeaponName)
	{
		ShipName = name;
		ShipSpeed = speed;
		ShipArmor = armor;
		ShipPrimaryWeaponName = primaryWeaponName;
		ShipPrimaryWeaponDamage = primaryWeaponDamage;
		ShipSecondaryWeaponName = secondaryWeaponName;
	}
}
