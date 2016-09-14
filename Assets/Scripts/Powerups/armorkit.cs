using UnityEngine;
using System.Collections;

public class armorpack : powerupBase {

	public override void activatePowerup (GameObject player)
	{
		Debug.LogWarning ("Picked up an Armor kit");
		plyStats.addArmor (10);
	}

}

