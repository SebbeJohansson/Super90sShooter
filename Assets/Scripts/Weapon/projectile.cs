using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

    private Rigidbody projRig;
    public int dmg;

	private float timer = 0.01f;

	// Use this for initialization
	void Start () {
        projRig = GetComponent<Rigidbody>();
        projRig.rotation = transform.rotation;
        projRig.freezeRotation = false;
        projRig.velocity = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z) * 10;
        //projRig.AddRelativeForce(Vector3.forward * 10000);
		timer += Time.fixedTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //projRig.AddRelativeForce(Vector3.forward * 1000);
	}

    /*void OnTriggerEnter(Collider coll)
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
		}

		Destroy (gameObject);
    }*/

    void OnCollisionEnter(Collision coll) {
        print(coll.gameObject);
        
        if (coll.gameObject.tag == "Player")
        {
            print(coll.gameObject.tag);
            /*if (coll.gameObject.GetComponent<PhotonView>() != null)
            {
                if (coll.gameObject.GetComponent<PhotonView>().isMine != true)
                {
                    print(coll.gameObject.GetComponent<PhotonView>());

                    print(coll.gameObject.GetComponent<PhotonView>().isMine);
                }
            }*/
            
        }
        

        /*if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<PhotonView>().isMine != true)
        {
            print("The thingy hit a player");
            //coll.gameObject.GetComponent<enemy>().damage(dmg);
        }*/

        print("Destroyed " + gameObject.name);
        Destroy(gameObject);
    }
    
    
}
