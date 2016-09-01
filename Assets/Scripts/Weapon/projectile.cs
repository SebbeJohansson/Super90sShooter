using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

    private Rigidbody projRig;
    public int dmg;

	private float timer = 0.01f;

	// Use this for initialization
	void Start () {
        projRig = GetComponent<Rigidbody>();
        projRig.freezeRotation = true;
        projRig.AddRelativeForce(Vector3.forward * 10000);
		timer += Time.fixedTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        projRig.AddRelativeForce(Vector3.forward * 1000);
	}

    void OnTriggerEnter(Collider coll)
    {
		if (coll.gameObject.tag == "Enemy") {
			coll.GetComponent<enemy> ().damage (dmg);
		} else if (coll.gameObject.tag == "Player") {
			if (coll.GetComponent<playerStats> () != null) {
				if (!coll.GetComponent<PhotonView>().isMine) {
					coll.GetComponent<playerStats> ().damage (dmg);
				}
			}

		}/* else {
			print (timer);
			print (Time.fixedTime);
			if (timer <= Time.fixedTime) {
				Destroy (gameObject);
			}
		}*/

		Destroy (gameObject);

        

    }
}
