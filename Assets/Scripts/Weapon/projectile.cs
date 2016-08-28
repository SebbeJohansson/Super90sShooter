using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

    private Rigidbody projRig;
    public int dmg;

	// Use this for initialization
	void Start () {
        projRig = GetComponent<Rigidbody>();
        projRig.freezeRotation = true;
        projRig.AddRelativeForce(Vector3.forward * 10000);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        projRig.AddRelativeForce(Vector3.forward * 1000);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.GetComponent<enemy>().damage(dmg);
        }

        Destroy(gameObject);

    }
}
