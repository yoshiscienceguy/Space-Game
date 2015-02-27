using UnityEngine;
using System.Collections;

public class trigger_garage : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			this.GetComponent<Animator> ().SetBool ("Open", true);

		}
	}
}
