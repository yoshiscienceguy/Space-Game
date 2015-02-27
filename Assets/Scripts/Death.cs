using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	
	// Use this for initialization
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel);

			
			
			
			//run animation
			//wait animationtime
			
		}
	}
	


}
