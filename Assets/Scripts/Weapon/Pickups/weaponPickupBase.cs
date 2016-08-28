using UnityEngine;
using System.Collections;

public class weaponPickupBase : MonoBehaviour {

    public int weaponId;

    private playerStats plyStats;
    private weaponBase weapon;

    void OnTriggerEnter(Collider coll) {
        if (coll.tag == "Player")
        {
            Debug.LogWarning("yea yea");
            activatePickup(coll.gameObject);
        }
    }

    public void activatePickup(GameObject player)
    {
        Debug.LogWarning("Pickedup " + weaponId);
        plyStats = player.GetComponent<playerStats>();
        weapon = player.GetComponentInChildren<weaponBase>();
        // Adds the weapon to player.
        plyStats.addWeapon(weaponId);
        // Equipes the weapon to player. This should probebly be a setting.
        weapon.activate(plyStats.findWeaponInInventory(weaponId));
        // Removed the pickup thingy.
        Destroy(gameObject);
    }

}
