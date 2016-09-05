using UnityEngine;
using System.Collections;

public class projectileSpawner : Photon.MonoBehaviour {

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
        mProjectile = (GameObject)PhotonNetwork.Instantiate(mProjectileType, transform.position, transform.rotation, 0);
        mProjectile.GetComponent<projectile>().dmg = dmg;
		mProjectile.GetComponent<projectile> ().createdByClient = true;
    }

}
