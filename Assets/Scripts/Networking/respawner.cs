using UnityEngine;
using System.Collections;

public class respawner : MonoBehaviour
{

    private playerStats playerStats;

    private spawnPoint spawnPoint;

    public spawnPoint[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        
        spawnPoints = FindObjectsOfType<spawnPoint>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void respawn()
    {
        print(getSpawnPoint().transform.position);
		playerStats = FindObjectOfType<playerStats>();
        playerStats.respawnPlayer(getSpawnPoint().transform.position);
    }

    public spawnPoint getSpawnPoint()
    {
        Random.seed = (int)Time.time;
        int randomNumber = Random.Range(0, spawnPoints.Length);
        spawnPoint = spawnPoints[randomNumber];
        return spawnPoint;
    }

}
