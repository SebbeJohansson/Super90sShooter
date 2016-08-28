using UnityEngine;
using System.Collections;

public class projectileSpawner : MonoBehaviour {

    //public GameObject projectilePrefab;

    private GameObject mProjectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnProjectile(int dmg, string projectileType)
    {
        string mProjectileType;
        if (projectileType == "laser")
        {
            mProjectileType = "LaserProjectile";
        }
        else
        {
            mProjectileType = "Projectile";
        }
        mProjectile = (GameObject)Instantiate(Resources.Load(mProjectileType));
        mProjectile.transform.position = transform.position;
        mProjectile.transform.rotation = transform.rotation;
        mProjectile.GetComponent<projectile>().dmg = dmg;
    }

}
