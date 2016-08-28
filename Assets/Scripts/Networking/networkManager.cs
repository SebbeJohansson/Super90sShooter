using UnityEngine;
using System.Collections;

public class networkManager : Photon.MonoBehaviour {

    private respawner respawner;
    
	// Use this for initialization
	void Start () {

        respawner = FindObjectOfType<respawner>();

        connect();
	}

    void connect()
    {
        //PhotonNetwork.ConnectToBestCloudServer("1.0");
        PhotonNetwork.ConnectUsingSettings("1.0");

        
        
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        print("yest");
        //PhotonNetwork.JoinOrCreateRoom("Random name", null, null);
        PhotonNetwork.JoinRandomRoom();
    }

    void OnCreateRoom()
    {
        Debug.Log("Created Room");
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Didnt find any random rooms.");
        PhotonNetwork.CreateRoom("Fuck you");

    }

    void OnJoinedRoom()
    {
        Debug.Log("Onjoinedroom");
        SpawnMyPlayer();

    }

    void SpawnMyPlayer()
    {
        Vector3 spawnpoint = respawner.getSpawnPoint().transform.position;

        GameObject player = PhotonNetwork.Instantiate("Player", spawnpoint, Quaternion.identity, 0);
        //player.transform.position = respawner.getSpawnPoint().transform.position;
        player.GetComponent<Rigidbody>().mass = 1;
        player.GetComponent<Rigidbody>().drag = 1.5f;
        player.GetComponent<Rigidbody>().angularDrag = 0.15f;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponentInChildren<Camera>().enabled = true;
        player.GetComponentInChildren<AudioListener>().enabled = true;
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<cameraMovement>().enabled = true;
        player.GetComponent<playerStats>().enabled = true;
        player.GetComponent<weaponTrigger>().enabled = true;

    }

}
