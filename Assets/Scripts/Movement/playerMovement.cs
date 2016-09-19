using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	private CharacterController playerController;
    private float speed;
    private float jumpVel;
	private float gravityDrag;
	private Vector3 moveDirection;
    
	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController>();
        speed = 15.0f;
        jumpVel = 8.0f;
		gravityDrag = 15.0f;
		moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        movement();
    }

    private void movement() {
		if(playerController.isGrounded == true){
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetKeyDown (KeyCode.Space)) {
				moveDirection.y = jumpVel;
			}
		}

		moveDirection.y -= gravityDrag * Time.deltaTime;
		playerController.Move (moveDirection * Time.deltaTime);
    }
}
