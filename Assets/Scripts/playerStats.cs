using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

    private int maxHP;
    private int currHP;

    private Camera deathCam;
    private Camera playerCam;
    
    private respawnTimer timer;

    private weaponDatabase weaponDatabase;

    public List<weapon> weaponInventory = new List<weapon>();

    private weaponBase gun;

	// Use this for initialization
	void Start () {
        maxHP = 100;
        currHP = maxHP;

        deathCam = GameObject.Find("DeathCamera").GetComponent<Camera>();
        deathCam.gameObject.SetActive(false);

        playerCam = GetComponentInChildren<Camera>();

        timer = FindObjectOfType<respawnTimer>();

        weaponDatabase = FindObjectOfType<weaponDatabase>();
        gun = GetComponentInChildren<weaponBase>();

        addWeapon(0);
        gun.activate(weaponInventory[0]);

	}

    void FixedUpdate()
    {
        //currHP--;
        isDead();
        if (Input.GetKeyDown(KeyCode.K))
        {
            killPlayer();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.activate(findWeaponInInventory(0));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.activate(findWeaponInInventory(1));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.reload();
        }
    }

	void OnTriggerEnter(Collider coll){
		print (coll.tag);
	}

	void OnCollisionEnter(Collision coll) {
		//if((coll.tag == "Bullet"/* && coll.GetComponent<Projectile>()*/) || coll.tag == "Explosion"){
		//currHP -= coll.GetComponent<Projectile>().getDamage();
		//isDead();
		//}
	}

    void showInventory()
    {
        for (int i = 0; i < weaponInventory.Count; i++)
        {
            print(weaponInventory[i].name);
        }
    }

    public weapon findWeaponInInventory(int weaponId)
    {
        for (int i = 0; i < weaponInventory.Count; i++)
        {
            if (weaponInventory[i].id == weaponId)
            {
                // Found correct weapon.
                return weaponInventory[i];
            }
        }

        // Didnt find the correct weapon. Returns default weapon (first weapon player picked up).

        return weaponInventory[0];

    }

    public void addWeapon(int id)
    {
        weapon mWeapon = weaponDatabase.getWeaponById(id);
        
        for (int i = 0; i < weaponInventory.Count; i++)
        {
            if (weaponInventory[i].id != mWeapon.id)
            {
                weaponInventory.Add(mWeapon);
                Debug.Log("Added a weapon called " + mWeapon.name + " to the players inventory.");
                break;
            }
            else if(weaponInventory[i].id == mWeapon.id)
            {
                gun.currentTotalAmmo = gun.maxTotalAmmo;
                gun.updateWeapon();
                Debug.Log("Set the ammo for the equiped weapon to full. Also updated it back to the inventory.");
                // I think we need to fix so that it also sets ammo
                // to full if player doesnt have the weapon equiped 
                // that of the same type that we are trying to add.
            }
        }

        if (weaponInventory.Count == 0)
        {
            weaponInventory.Add(mWeapon);

            Debug.Log("Added a weapon called " + mWeapon.name + " to the players inventory.");
        }
        
        
    }

    void death() {
        deathCam.gameObject.SetActive(true);
        playerCam.gameObject.SetActive(false);
        timer.startTimer();
        transform.position = new Vector3(0, 0, 0);
    }

    

    void isDead()
    {
        if (currHP <= 0)
        {
            death();
        }
    }

    public void respawnPlayer(Vector3 spawnPoint)
    {
        currHP = maxHP;
        deathCam.gameObject.SetActive(false);
        playerCam.gameObject.SetActive(true);
        transform.position = spawnPoint;
    }

    void killPlayer()
    {
        currHP = 0;
    }

	public void damage(int dmg)
	{
		Debug.Log ("Player took " + dmg + " damage.");
		currHP -= dmg;
	}


}
