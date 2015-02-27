using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	public GameObject DragonController;
	public GameObject Dragon;
	public string Trigger_Name;
	// Use this for initialization

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Dragon.GetComponent<Animator> ().SetBool (Trigger_Name, true);
			DragonController.GetComponent<Animator> ().SetBool (Trigger_Name, true);
		}
	}
}
