using UnityEngine;
using System.Collections;

public class weaponTrigger : MonoBehaviour {

    private weaponBase weapon;

    float timePassed = 0;

	// Use this for initialization
	void Start () {
        weapon = GetComponentInChildren<weaponBase>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(0))
        {
            fireWeapon();
        }
	}

    void fireWeapon()
    {
        if (timePassed <= Time.fixedTime)
        {
            weapon.fire();
            timePassed = Time.fixedTime + (60 / (float)weapon.fireRate);
        }
    }

}
