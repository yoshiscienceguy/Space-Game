using UnityEngine;
using System.Collections;

public class Player_Backpack : MonoBehaviour {
	public GameObject Key;
	public GameObject Blackbox;
	private bool[] Backpack = new bool[2];
	// Use this for initialization
	void Start () {
		Key.SetActive (false);
		Blackbox.SetActive (false);
		Backpack [0] = false;
		Backpack [1] = false;
	}


	// Update is called once per frame
	public void Enable_Object(string name){
		if (name == "Black Box") {
			Backpack[1] = true;
			Blackbox.SetActive(true);
		}
		if (name == "Key") {
			Backpack[0] = true;		
			Key.SetActive(true);
		}
	}

	public bool If_Enabled(string name){
		if(name == "Black Box"){
			return Backpack[1];
		}
		if (name == "Key") {
			return Backpack[0];	
		}
		return false;
	}

	public void Use_Object(string name){
		if (name == "Black Box") {
			Backpack[1] = false;
			Blackbox.SetActive(false);

		}
		if (name == "Key") {
			Backpack[0] = false;
			Key.SetActive(false);
		}
	}
}
