using UnityEngine;
using System.Collections;

public class Dragon_Hit_detector : MonoBehaviour {


	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Demious") {
			GetComponent<Animator>().SetBool("Hit",true);
		}
	}
}
