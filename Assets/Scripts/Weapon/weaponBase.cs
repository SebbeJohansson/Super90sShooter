using UnityEngine;
using System.Collections;

public class weaponBase : MonoBehaviour
{
    public string name; // Name of Weapon.
    public int damage; // Damage per round.
    public int reloadTime; // Time to reload.
    public int fireRate; // Time between rounds.
    public int currentClipAmmo; // Current ammo in loaded clip.
    public int maxClipAmmo; // Max ammo 1 clip can hold.
    public int currentTotalAmmo; // Current total ammo player has.
    public int maxTotalAmmo; // Max ammo player can have.
    public string projectileType;

    private weapon currentWeapon;

    private projectileSpawner projSpawner;

    float reloadTimer = 0;

    void Start()
    {
        projSpawner = GetComponentInChildren<projectileSpawner>(); 
    }

    public void activate(weapon mWeapon)
    {
        name = mWeapon.name;
        damage = mWeapon.damage;
        reloadTime = mWeapon.reloadTime;
        fireRate = mWeapon.fireRate;
        currentClipAmmo = mWeapon.maxClipAmmo;
        maxClipAmmo = mWeapon.maxClipAmmo;
        currentTotalAmmo = mWeapon.maxTotalAmmo;
        maxTotalAmmo = mWeapon.maxTotalAmmo;
        projectileType = mWeapon.projectileType;

        currentWeapon = mWeapon;

        Debug.Log("Equiped the " + mWeapon.name);

    }

    public void updateWeapon()
    {
        currentWeapon.name = name;
        currentWeapon.damage = damage;
        currentWeapon.reloadTime = reloadTime;
        currentWeapon.fireRate = fireRate;
        currentWeapon.currentClipAmmo = maxClipAmmo;
        currentWeapon.maxClipAmmo = maxClipAmmo;
        currentWeapon.currentTotalAmmo = maxTotalAmmo;
        currentWeapon.maxTotalAmmo = maxTotalAmmo;
    }

    public void fire()
    {
        if (currentClipAmmo > 0)
        {
            if (reloadTimer <= Time.fixedTime)
            {
                print("Pew Pew Pew");
                currentClipAmmo -= 1;
                projSpawner.spawnProjectile(damage, projectileType);
                if (currentClipAmmo < 0)
                {
                    reload();
                }
            }
        }
        else
        {
            reload();
            
        }
        updateWeapon();
    }

    public void reload()
    {
        reloadTimer = Time.fixedTime + (reloadTime / 1000);
        if (currentTotalAmmo > 0)
        {
            int tempClip = maxClipAmmo - currentClipAmmo;
            if (tempClip <= currentTotalAmmo)
            {
                currentClipAmmo += tempClip;
                currentTotalAmmo -= tempClip;
            }
            else if (currentTotalAmmo != 0)
            {
                currentClipAmmo += currentTotalAmmo;
                currentTotalAmmo = 0;
            }
        }
        updateWeapon();
    }


}
