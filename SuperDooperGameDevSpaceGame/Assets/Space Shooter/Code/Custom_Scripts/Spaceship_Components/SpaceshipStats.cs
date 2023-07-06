using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpaceshipStats
{
	public string ShipName;
	public int ShipArmor;
	public string ShipPrimaryWeaponName;
	public int ShipPrimaryWeaponDamage;
	public string ShipSecondaryWeaponName;
	public int ShipSecondaryWeaponDamage;

    public SpaceshipStats(string name, int armor, string primaryWeaponName, int primaryWeaponDamage, string secondaryWeaponName, int secondaryWeaponDamage)
	{
		ShipName= name;
		ShipArmor= armor;
		ShipPrimaryWeaponName= primaryWeaponName;
		ShipPrimaryWeaponDamage= primaryWeaponDamage;
		ShipSecondaryWeaponName= secondaryWeaponName;
		ShipSecondaryWeaponDamage= secondaryWeaponDamage;
	}
}
