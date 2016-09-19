using UnityEngine;
using System.Collections;

public class powerupBase : MonoBehaviour {

    //public int weaponId;

    public playerStats plyStats;
    //private weaponBase weapon;

    void OnTriggerEnter(Collider coll) {
        if (coll.tag == "Player")
        {
            Debug.LogWarning("Player picked up a powerup");
			plyStats = coll.gameObject.GetComponent<playerStats> ();
            activatePowerup(coll.gameObject);
        }
    }

	virtual public void activatePowerup (GameObject player){}
    /*{
        Debug.LogWarning("Pickedup " + weaponId);
        plyStats = player.GetComponent<playerStats>();
        weapon = player.GetComponentInChildren<weaponBase>();
        // Adds the weapon to player.
        plyStats.addWeapon(weaponId);
        // Equipes the weapon to player. This should probebly be a setting.
        weapon.activate(plyStats.findWeaponInInventory(weaponId));
        // Removed the pickup thingy.
        Destroy(gameObject);
    }*/

}
