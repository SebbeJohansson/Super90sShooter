using UnityEngine;
using System.Collections;

public class hudDisplayer : MonoBehaviour {

	public int currHP;
	public int currArmor;

	hpHud hpHudElement;
	armorHud armorHudElement;

	// Use this for initialization
	void Start () {
		hpHudElement = GetComponentInChildren<hpHud> ();
		armorHudElement = GetComponentInChildren<armorHud> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateHud(int hp, int armor){
		currHP = hp;
		currArmor = armor;
		setHud ();
	}

	void setHud(){
		hpHudElement.setText (currHP);
		armorHudElement.setText (currArmor);
	}

}
