using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    private float sensitivityX = 15F;
    private float sensitivityY = 15F;

    /*private float minimumX = -360F;
    private float maximumX = 360F;*/

    private float minimumY = -60F;
    private float maximumY = 60F;

    private float rotationY = 0F;

    private Transform playerTransform;
    private Camera playerCamera;

	// Use this for initialization
	void Start () {
        playerCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerRotation();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }



	}



    private void playerRotation() {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        playerCamera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }
}
