using UnityEngine;
using System.Collections;

public class Bullet_Destroyer : MonoBehaviour {
	public float time = 1.5f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, time);
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Untagged") {
			Destroy(gameObject);
		}
	}




}
