using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class respawnTimer : MonoBehaviour {

    public float respawnTime = 5;

    private float timer;
    private bool timerStarted;
    
    private Text deathTimerText;

    private respawner respawner;

	// Use this for initialization
	void Start () {
        timerStarted = false;

        timer = respawnTime;

        deathTimerText = GetComponent<Text>();
        deathTimerText.fontSize = Screen.height / 8;

        respawner = FindObjectOfType<respawner>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timerStarted == true)
        {
            timer -= Time.deltaTime;
            deathTimerText.text = timer.ToString("0");
            if (timer <= 0)
            {
                print("Timer stopped");
                timerStarted = false;
                respawner.respawn();
                timer = respawnTime;
                deathTimerText.text = "";
            }
        }
	}

    public void startTimer()
    {
        timerStarted = true;
    }
}
