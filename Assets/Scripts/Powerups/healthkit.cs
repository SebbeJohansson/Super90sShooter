using UnityEngine;
using System.Collections;

public class healthkit : powerupBase {

	public override void activatePowerup (GameObject player)
	{
		Debug.LogWarning ("Picked up a healthkit hell yea");
		plyStats.addHP (10);
	}

}
