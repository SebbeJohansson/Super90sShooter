using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class armorHud : MonoBehaviour {

	Text ArmorText;

	// Use this for initialization
	void Start () {
		ArmorText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void setText(int armor){
		ArmorText.text = "Armor: " + armor;
	}
}
