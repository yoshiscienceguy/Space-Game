using UnityEngine;
using System.Collections;

public class LevelOneChangeScript : MonoBehaviour {

	// Use this for initialization
	public float delay = 9;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {

			StartCoroutine(FireRate());
				


			//run animation
			//wait animationtime

		}
	}

	IEnumerator FireRate(){

		yield return new WaitForSeconds(delay);
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}
}
