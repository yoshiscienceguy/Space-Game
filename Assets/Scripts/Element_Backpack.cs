using UnityEngine;
using System.Collections;

public class Element_Backpack : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.GetComponent<Player_Backpack> ().Enable_Object (this.name);
			gameObject.SetActive(false);
		}
	}
}
