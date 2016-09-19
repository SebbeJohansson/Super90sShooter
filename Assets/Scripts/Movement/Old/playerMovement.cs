using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private Rigidbody playerRigid;
    private float speed;
    private float jumpVel;
    private bool grounded;
    private int topSpeed;
    
	// Use this for initialization
	void Start () {
        playerRigid = GetComponent<Rigidbody>();
        playerRigid.freezeRotation = true;
        speed = 20.0f;
        jumpVel = 300.0f;
        topSpeed = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movement();
        jump();
    }

    private void movement() {
        //playerRigid.velocity += new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        if (playerRigid.velocity.magnitude < topSpeed) {
            playerRigid.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * speed);
            playerRigid.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * speed);
        }
    }

    private void jump() {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true) {
            playerRigid.AddForce(Vector3.up * jumpVel);
        }
    }

    private void OnCollisionEnter() {
        grounded = true;
    }

    private void OnCollisionExit() {
        grounded = false;
    }
}
