using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using LitJson;

public class weaponDatabase : MonoBehaviour {

    public List<weapon> database = new List<weapon>();
    private JsonData weaponData;

	// Use this for initialization
	void Start () {
        weaponData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/weaponTypes.json"));
        createDatabase();

        for (int i = 0; i < database.Count; i++)
		{
            print(database[i].name);
		}
        
	}

    // Create database.
    void createDatabase()
    {
        for (int i = 0; i < weaponData.Count; i++)
        {
            database.Add(new weapon(
                (int)weaponData[i]["id"],
                weaponData[i]["name"].ToString(),
                (int)weaponData[i]["damage"],
                (int)weaponData[i]["reloadTime"], 
                (int)weaponData[i]["fireRate"],
                (int)weaponData[i]["maxClipAmmo"],
                (int)weaponData[i]["maxTotalAmmo"],
                weaponData[i]["projectileType"].ToString(),
                weaponData[i]["slug"].ToString()));
        }
    }

    public weapon getWeaponById(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].id == id)
            {
                return database[i];
            }
        }
        // Weapon by the id wasnt found.
        print("No weapon by this id in database");
        return null;
    }

}

public class weapon {
    public int id { get; set; } // Id for weapon.
    public string name { get; set; } // Name of Weapon.
    public int damage { get; set; } // Damage per round.
    public int reloadTime { get; set; } // Time to reload.
    public int fireRate { get; set; } // Time between rounds.
    public int currentClipAmmo; // Current ammo in loaded clip.
    public int maxClipAmmo { get; set; } // Max ammo 1 clip can hold.
    public int currentTotalAmmo; // Current total ammo player has.
    public int maxTotalAmmo { get; set; } // Max ammo player can have.
    public string projectileType { get; set; }
    public string slug { get; set; } // Slug for weapon.

    // Constructor
    public weapon(int mId, string mName, int mDamage, int mReloadTime, int mFireRate, int mMaxClipAmmo, int mMaxTotalAmmo, string mProjectile, string mSlug)
    {
        this.id = mId;
        this.name = mName;
        this.damage = mDamage;
        this.reloadTime = mReloadTime;
        this.fireRate = mFireRate;
        this.maxClipAmmo = mMaxClipAmmo;
        this.maxTotalAmmo = mMaxTotalAmmo;
        this.projectileType = mProjectile;
        this.slug = mSlug;
    }
}
