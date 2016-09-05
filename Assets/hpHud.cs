using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpHud : MonoBehaviour {

	Text hpText;

	// Use this for initialization
	void Start () {
		hpText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(int hp){
		hpText.text = "HP: " + hp;
	}
}
